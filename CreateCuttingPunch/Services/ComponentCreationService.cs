using CreateCuttingPunch.Model;
using NXOpen;
using NXOpen.Annotations;
using NXOpen.CAE;
using NXOpen.Features;
using NXOpen.UF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CreateCuttingPunch.Constants.Const;

namespace CreateCuttingPunch.Services
{
    public class ComponentCreationService
    {
        bool debugMode = false;
        public Part CreateNewComponent(ComponentCreationConfig config)
        {
            Session session = Session.GetSession();
            FileNew fileNew = session.Parts.FileNew();

            // Phase 1: File Setup (common across all components)
            ConfigureFileNew(fileNew, config);

            try
            {
                // Phase 2: File Commit & Basic Setup (common)
                NXObject componentObject = fileNew.Commit();
                Part workPart = session.Parts.Work;
                Part displayPart = session.Parts.Display;
                fileNew.Destroy();
                session.ApplicationSwitchImmediate(NxTemplate.UG_APP_MODELING);

                // Phase 3: Color Assignment (delegated to specific component logic)
                if (config.ColorAssignmentAction != null)
                {
                    config.ColorAssignmentAction(workPart, config.FileName);
                }

                // Phase 4: Part Properties Update (common pattern)
                UpdatePartProperties(config);

                // Phase 5: Sketch generation
                //GenerateSketch(config);

                // Phase 7: Save Operations (common)
                SaveComponent(workPart);
                return workPart;
            }
            catch (NXException nxEx) when (nxEx.Message.Contains("File already exists"))
            {
                string message = $"File already exists: {config.FileName}{NxTemplate.EXTENSION}\n\n" +
                               $"Location: {config.FolderPath}\n\n" +
                               "Please:\n" +
                               "• Delete the existing file, or\n" +
                               "• Choose a different output directory, or\n" +
                               "• Modify the project code prefix";

                NXDrawing.ShowMessageBox(message, "File Conflict", NXOpen.NXMessageBox.DialogType.Warning);
                throw new InvalidOperationException($"Cannot create component '{config.FileName}' - file already exists", nxEx);
            }
        }

        public void ProjectProfile(ComponentCreationConfig config)
        {
            // ----------------------------------------------
            //   Menu: Insert->Derived Curve->Project...
            // ----------------------------------------------
            Session theSession = Session.GetSession();
            Part workPart = theSession.Parts.Work;
            Part displayPart = theSession.Parts.Display;

            NXOpen.Features.Feature nullNXOpen_Features_Feature = null;
            NXOpen.Features.ProjectCurveBuilder projectCurveBuilder1;
            projectCurveBuilder1 = workPart.Features.CreateProjectCurveBuilder(nullNXOpen_Features_Feature);

            NXOpen.Point3d origin1 = new NXOpen.Point3d(0.0, 0.0, 0.0);
            NXOpen.Vector3d normal1 = new NXOpen.Vector3d(0.0, 0.0, 1.0);
            NXOpen.Plane plane1;
            plane1 = workPart.Planes.CreatePlane(origin1, normal1, NXOpen.SmartObject.UpdateOption.WithinModeling);

            NXOpen.Unit unit1 = ((NXOpen.Unit)workPart.UnitCollection.FindObject("MilliMeter"));
            NXOpen.Expression expression1;
            expression1 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);

            NXOpen.Expression expression2;
            expression2 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);

            projectCurveBuilder1.CurveFitData.Tolerance = 0.001;

            projectCurveBuilder1.CurveFitData.AngleTolerance = 0.01;

            projectCurveBuilder1.ProjectionDirectionMethod = NXOpen.Features.ProjectCurveBuilder.DirectionType.AlongVector;

            projectCurveBuilder1.ProjectionDirectionMethod = NXOpen.Features.ProjectCurveBuilder.DirectionType.AngleToVector;

            projectCurveBuilder1.AngleToProjectionVector.SetFormula("0");
            

            NXOpen.Point3d origin2 = new NXOpen.Point3d(10.000000000000057, 0.0, -77.550000000000011);
            NXOpen.Vector3d vector1 = new NXOpen.Vector3d(0.0, 0.0, 1.0);
            NXOpen.Direction direction1;
            direction1 = workPart.Directions.CreateDirection(origin2, vector1, NXOpen.SmartObject.UpdateOption.WithinModeling);

            projectCurveBuilder1.ProjectionVector = direction1;

            projectCurveBuilder1.SectionToProject.DistanceTolerance = 0.001;

            projectCurveBuilder1.SectionToProject.ChainingTolerance = 0.00095;

            projectCurveBuilder1.SectionToProject.AngleTolerance = 0.01;

            projectCurveBuilder1.SectionToProject.SetAllowedEntityTypes(NXOpen.Section.AllowTypes.CurvesAndPoints);

            NXOpen.ScCollector scCollector1;
            scCollector1 = workPart.ScCollectors.CreateCollector();

            NXOpen.SelectionIntentRuleOptions selectionIntentRuleOptions1;
            selectionIntentRuleOptions1 = workPart.ScRuleFactory.CreateRuleOptions();

            selectionIntentRuleOptions1.SetSelectedFromInactive(false);

            NXOpen.DatumPlane[] faces1 = new NXOpen.DatumPlane[1];            
            DatumPlane datumPlane1 = AskXYDatumPlane();

            faces1[0] = datumPlane1;
            NXOpen.FaceDumbRule faceDumbRule1;
            faceDumbRule1 = workPart.ScRuleFactory.CreateRuleFaceDatum(faces1, selectionIntentRuleOptions1);

            selectionIntentRuleOptions1.Dispose();
            NXOpen.SelectionIntentRule[] rules1 = new NXOpen.SelectionIntentRule[1];
            rules1[0] = faceDumbRule1;
            scCollector1.ReplaceRules(rules1, false);

            bool added1;
            added1 = projectCurveBuilder1.FaceToProjectTo.Add(scCollector1);                        

            NXOpen.Features.CompositeCurveBuilder compositeCurveBuilder1;
            compositeCurveBuilder1 = workPart.Features.CreateCompositeCurveBuilder(nullNXOpen_Features_Feature);

            NXOpen.Section section1;
            section1 = compositeCurveBuilder1.Section;

            compositeCurveBuilder1.Associative = true;

            compositeCurveBuilder1.ParentPart = NXOpen.Features.CompositeCurveBuilder.PartType.OtherPart;

            compositeCurveBuilder1.AllowSelfIntersection = true;

            section1.SetAllowedEntityTypes(NXOpen.Section.AllowTypes.CurvesAndPoints);

            section1.SetAllowRefCrvs(false);

            compositeCurveBuilder1.FixAtCurrentTimestamp = true;

            NXOpen.SelectionIntentRuleOptions selectionIntentRuleOptions2;
            selectionIntentRuleOptions2 = workPart.ScRuleFactory.CreateRuleOptions();

            selectionIntentRuleOptions2.SetSelectedFromInactive(false);
                                    
            TaggedObject sheet = config.SheetObject;
            Body sheetBody = sheet as Body;
            Edge edge1 = sheetBody.GetEdges().First();

            NXOpen.Edge nullNXOpen_Edge = null;
            NXOpen.EdgeTangentRule edgeTangentRule1;
            edgeTangentRule1 = workPart.ScRuleFactory.CreateRuleEdgeTangent(edge1, nullNXOpen_Edge, true, 0.01, false, false, selectionIntentRuleOptions2);

            selectionIntentRuleOptions2.Dispose();
            NXOpen.SelectionIntentRule[] rules2 = new NXOpen.SelectionIntentRule[1];
            rules2[0] = edgeTangentRule1;
            NXOpen.NXObject nullNXOpen_NXObject = null;
            NXOpen.Point3d helpPoint1 = new NXOpen.Point3d(55.0, 61.04694916834319, 0.0);
            section1.AddToSection(rules2, edge1, nullNXOpen_NXObject, nullNXOpen_NXObject, helpPoint1, NXOpen.Section.Mode.Create, false);            

            NXOpen.Features.Feature feature1;
            feature1 = compositeCurveBuilder1.CommitCreateOnTheFly();            

            NXOpen.GeometricUtilities.WaveLinkRepository waveLinkRepository1;
            waveLinkRepository1 = workPart.CreateWavelinkRepository();

            waveLinkRepository1.SetNonFeatureApplication(false);

            waveLinkRepository1.SetBuilder(projectCurveBuilder1);

            NXOpen.Features.CompositeCurve compositeCurve1 = ((NXOpen.Features.CompositeCurve)feature1);
            waveLinkRepository1.SetLink(compositeCurve1);

            NXOpen.Features.CompositeCurveBuilder compositeCurveBuilder2;
            compositeCurveBuilder2 = workPart.Features.CreateCompositeCurveBuilder(compositeCurve1);

            compositeCurveBuilder2.Associative = false;            

            NXOpen.Features.Feature feature2;
            feature2 = compositeCurveBuilder2.CommitCreateOnTheFly();

            compositeCurveBuilder2.Destroy();            

            compositeCurveBuilder1.Destroy();            

            NXOpen.SelectionIntentRuleOptions selectionIntentRuleOptions3;
            selectionIntentRuleOptions3 = workPart.ScRuleFactory.CreateRuleOptions();

            selectionIntentRuleOptions3.SetSelectedFromInactive(false);

            NXOpen.Features.Feature[] features1 = new NXOpen.Features.Feature[1];
            NXOpen.Features.CompositeCurve compositeCurve2 = ((NXOpen.Features.CompositeCurve)feature2);
            features1[0] = compositeCurve2;
            NXOpen.DisplayableObject nullNXOpen_DisplayableObject = null;
            NXOpen.CurveFeatureRule curveFeatureRule1;
            curveFeatureRule1 = workPart.ScRuleFactory.CreateRuleCurveFeature(features1, nullNXOpen_DisplayableObject, selectionIntentRuleOptions3);

            selectionIntentRuleOptions3.Dispose();
            projectCurveBuilder1.SectionToProject.AllowSelfIntersection(true);

            projectCurveBuilder1.SectionToProject.AllowDegenerateCurves(false);

            NXOpen.SelectionIntentRule[] rules3 = new NXOpen.SelectionIntentRule[1];
            rules3[0] = curveFeatureRule1;
            //NXOpen.Line line1 = ((NXOpen.Line)compositeCurve2.FindObject("CURVE 1 {3 (65.0000000000001,59.3533152929391,-77.55)}"));
            NXOpen.Point3d helpPoint2 = new NXOpen.Point3d(65.000000000000057, 61.04694916834319, -77.550000000000011);
            projectCurveBuilder1.SectionToProject.AddToSection(rules3, edge1, nullNXOpen_NXObject, nullNXOpen_NXObject, helpPoint2, NXOpen.Section.Mode.Create, false);                                                     

            NXOpen.NXObject nXObject1;
            nXObject1 = projectCurveBuilder1.Commit();           

            projectCurveBuilder1.SectionToProject.CleanMappingData();

            projectCurveBuilder1.SectionToProject.CleanMappingData();

            NXOpen.Expression expression3 = projectCurveBuilder1.AngleToProjectionVector;
            projectCurveBuilder1.Destroy();            

            plane1.DestroyPlane();

            waveLinkRepository1.Destroy();
        }

        public void ProjectPunchProfile(ComponentCreationConfig config)
        {
            if (debugMode)
                System.Diagnostics.Debugger.Launch();

            //Part workPart = Session.GetSession().Parts.Work;
            var ufs = UFSession.GetUFSession();
            

            //Tag[] tagPlanes = AskXYDatumPlane();
            //config.tagPlanes = tagPlanes;            

            //int along_face_normal = 3;
            //Tag proj_curve_feature;
            //double[] proj_vector = { 0.0, 0.0, 1.0 };

            //try
            //{                               
            //    ufs.Modl.CreateProjCurves(
            //        config.tagCurves,
            //        config.tagPlanes,
            //        along_face_normal,
            //        proj_vector,
            //        out proj_curve_feature);
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception($"Project Curve Error: {ex.Message}");
            //}
            Part workPart = Session.GetSession().Parts.Work;
            ProjectCurveBuilder projectCurveBuilder1 = workPart.Features.CreateProjectCurveBuilder(null);
            projectCurveBuilder1.CurveFitData.Tolerance = 0.001;
            projectCurveBuilder1.CurveFitData.AngleTolerance = 0.01;
            projectCurveBuilder1.ProjectionDirectionMethod = ProjectCurveBuilder.DirectionType.AlongVector;            
            projectCurveBuilder1.AngleToProjectionVector.SetFormula("0");
            Direction direction1 = workPart.Directions.CreateDirection(
                new Point3d(0, 0, 0),
                new Vector3d(0,0,1),
                SmartObject.UpdateOption.WithinModeling
                );

            projectCurveBuilder1.ProjectionVector = direction1;

            NXOpen.GeometricUtilities.WaveLinkRepository waveLinkRepository1 = workPart.CreateWavelinkRepository();
            waveLinkRepository1.SetNonFeatureApplication(false);
            waveLinkRepository1.SetBuilder(projectCurveBuilder1);

            CompositeCurveBuilder compositeCurveBuilder1 = workPart.Features.CreateCompositeCurveBuilder(null);

            Feature feature1 = compositeCurveBuilder1.CommitCreateOnTheFly();

            CompositeCurve compositeCurve1 = (CompositeCurve)feature1;
            waveLinkRepository1.SetLink(compositeCurve1);
            CompositeCurveBuilder compositeCurveBuilder2 = workPart.Features.CreateCompositeCurveBuilder(compositeCurve1);

            Feature feature2 = compositeCurveBuilder2.CommitCreateOnTheFly();

            Feature[] features1 = new Feature[1];
            CompositeCurve compositeCurve2 = (CompositeCurve)feature2;
            features1[0] = compositeCurve2;

            SelectionIntentRuleOptions selectionIntentRuleOptions3 = workPart.ScRuleFactory.CreateRuleOptions();
            selectionIntentRuleOptions3.SetSelectedFromInactive(false);

            CurveFeatureRule curveFeatureRule = workPart.ScRuleFactory.CreateRuleCurveFeature(
                features1,
                null,
                selectionIntentRuleOptions3
                );

            selectionIntentRuleOptions3.Dispose();

            SelectionIntentRule[] rules3 = new SelectionIntentRule[1];
            rules3[0] = curveFeatureRule;

            var nxObjs = compositeCurve2.GetEntities();
            NXObject seed = null;
            Point3d helpPoint2 = new Point3d(0,0,0);
            foreach (var obj in nxObjs)
            {
                if (obj is Line line)
                { 
                    seed = obj;
                    Line line1 = (Line)line;
                    helpPoint2 = line1.StartPoint;
                    break;
                }
                else if (obj is Arc arc)
                {
                    {
                        seed = obj;
                        Arc arc1 = (Arc)arc;
                        helpPoint2 = arc1.CenterPoint;
                        break;
                    }
                }
            }            

            projectCurveBuilder1.SectionToProject.AddToSection(
                rules3,
                seed,
                null,
                null,
                helpPoint2,
                Section.Mode.Create,
                false
                );

            NXObject projectCurve;
            projectCurve = projectCurveBuilder1.Commit();

            projectCurveBuilder1.Destroy();
        }

        private DatumPlane AskXYDatumPlane()
        {
            Part workPart = Session.GetSession().Parts.Work;            

            foreach (var obj in workPart.Datums)
            {
                if (obj is DatumPlane datum)
                {
                    if (
                    datum.Normal.X == 0 &&
                    datum.Normal.Y == 0 &&
                    datum.Normal.Z == 1)
                    {
                        return datum;
                    }
                }
            }

            return null;
        }

        private void SaveComponent(Part workPart)
        {
            BasePart.SaveComponents saveComponentParts = BasePart.SaveComponents.True;
            BasePart.CloseAfterSave close = BasePart.CloseAfterSave.True;
            workPart.Save(saveComponentParts, close);
        }

        private void UpdatePartProperties(ComponentCreationConfig config)
        {
            Part workPart = Session.GetSession().Parts.Work;
            TitleBlockProperties properties = new TitleBlockProperties(
                workPart,
                config.ProjectInfo.Designer,
                config.DrawingCode,
                config.Hardness,
                config.ItemName,
                config.Length,
                config.Thickness,
                config.Width,
                config.Material,
                config.ProjectInfo.Model,
                config.ProjectInfo.Part
                );
            var attrList = properties.AttributeInfoToList(Constants.Const.Attributes.CATEGORY_TITLEBLOCK, properties.Properties);
            properties.SetAttributesByList(attrList);

            NXObject.AttributeInformation info = new NXObject.AttributeInformation();
            info.Category = Constants.Const.Attributes.CATEGORY_TOOL;
            info.Title = Constants.Const.Attributes.PART_TYPE;
            info.Type = NXObject.AttributeType.String;
            info.StringValue = config.PartPropertiesType;
            properties.SetAttribute(info);
        }

        private void ConfigureFileNew(FileNew fileNew, ComponentCreationConfig config)
        {
            fileNew.TemplateFileName = config.TemplateFileName;
            fileNew.UseBlankTemplate = false;
            fileNew.ApplicationName = Constants.Const.NxTemplate.MODEL_TEMPLATE;
            fileNew.Units = Part.Units.Millimeters;
            fileNew.TemplatePresentationName = config.PresentationName;
            fileNew.SetCanCreateAltrep(false);
            fileNew.NewFileName = $"{config.FolderPath}{config.FileName}{Constants.Const.NxTemplate.EXTENSION}";
            fileNew.MakeDisplayedPart = true; // or false, need test
            fileNew.DisplayPartOption = NXOpen.DisplayPartOption.AllowAdditional;
        }
    }
}
