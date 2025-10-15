using CreateCuttingPunch.Model;
using NXOpen;
using NXOpen.Annotations;
using NXOpen.CAE;
using NXOpen.Features;
using NXOpen.Layout2d;
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

                // Test Features dump infomation
                //AskSketchFeatureByName("MAIN");

                // Phase 7: Save Operations (common)
                SaveNCloseComponent(workPart);
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

        public void ExtrudeSketchByName(string sketchName, string punchLength)
        {
            NXOpen.Session theSession = NXOpen.Session.GetSession();
            NXOpen.Part workPart = theSession.Parts.Work;
            NXOpen.Part displayPart = theSession.Parts.Display;
            // ----------------------------------------------
            //   Menu: Insert->Design Feature->Extrude...
            // ----------------------------------------------            

            NXOpen.Features.Feature nullNXOpen_Features_Feature = null;
            NXOpen.Features.ExtrudeBuilder extrudeBuilder1;
            extrudeBuilder1 = workPart.Features.CreateExtrudeBuilder(nullNXOpen_Features_Feature);

            NXOpen.Section section1;
            section1 = workPart.Sections.CreateSection(0.00095, 0.001, 0.01);

            extrudeBuilder1.Section = section1;

            extrudeBuilder1.AllowSelfIntersectingSection(true);

            NXOpen.Unit unit1;
            unit1 = extrudeBuilder1.Draft.FrontDraftAngle.Units;

            NXOpen.Expression expression1;
            expression1 = workPart.Expressions.CreateSystemExpressionWithUnits("2.00", unit1);

            extrudeBuilder1.DistanceTolerance = 0.001;

            extrudeBuilder1.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Create;

            NXOpen.Body[] targetBodies1 = new NXOpen.Body[1];
            NXOpen.Body nullNXOpen_Body = null;
            targetBodies1[0] = nullNXOpen_Body;
            extrudeBuilder1.BooleanOperation.SetTargetBodies(targetBodies1);

            extrudeBuilder1.Limits.StartExtend.Value.SetFormula("0");

            extrudeBuilder1.Limits.EndExtend.Value.SetFormula(punchLength);

            extrudeBuilder1.Draft.FrontDraftAngle.SetFormula("45");

            extrudeBuilder1.Draft.BackDraftAngle.SetFormula("2");

            extrudeBuilder1.Offset.StartOffset.SetFormula("0");

            extrudeBuilder1.Offset.EndOffset.SetFormula("5");

            NXOpen.GeometricUtilities.SmartVolumeProfileBuilder smartVolumeProfileBuilder1;
            smartVolumeProfileBuilder1 = extrudeBuilder1.SmartVolumeProfile;

            smartVolumeProfileBuilder1.OpenProfileSmartVolumeOption = false;

            smartVolumeProfileBuilder1.CloseProfileRule = NXOpen.GeometricUtilities.SmartVolumeProfileBuilder.CloseProfileRuleType.Fci;

            NXOpen.Point3d origin1 = new NXOpen.Point3d(0.0, 0.0, 0.0);
            NXOpen.Vector3d vector1 = new NXOpen.Vector3d(-0.0, -0.0, -1.0);
            NXOpen.Direction direction1;
            direction1 = workPart.Directions.CreateDirection(origin1, vector1, NXOpen.SmartObject.UpdateOption.WithinModeling);

            extrudeBuilder1.Direction = direction1;

            extrudeBuilder1.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Create;

            NXOpen.Body[] targetBodies2 = new NXOpen.Body[1];
            targetBodies2[0] = nullNXOpen_Body;
            extrudeBuilder1.BooleanOperation.SetTargetBodies(targetBodies2);

            NXOpen.Body[] targetBodies3 = new NXOpen.Body[0];
            extrudeBuilder1.BooleanOperation.SetTargetBodies(targetBodies3);

            extrudeBuilder1.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Create;

            NXOpen.Body[] targetBodies4 = new NXOpen.Body[1];
            targetBodies4[0] = nullNXOpen_Body;
            extrudeBuilder1.BooleanOperation.SetTargetBodies(targetBodies4);

            NXOpen.Body[] targetBodies5 = new NXOpen.Body[0];
            extrudeBuilder1.BooleanOperation.SetTargetBodies(targetBodies5);

            section1.DistanceTolerance = 0.001;

            section1.ChainingTolerance = 0.00095;

            section1.SetAllowedEntityTypes(NXOpen.Section.AllowTypes.OnlyCurves);

            NXOpen.SelectionIntentRuleOptions selectionIntentRuleOptions1;
            selectionIntentRuleOptions1 = workPart.ScRuleFactory.CreateRuleOptions();

            selectionIntentRuleOptions1.SetSelectedFromInactive(false);

            NXOpen.Features.Feature[] features1 = new NXOpen.Features.Feature[1];
            NXOpen.Features.SketchFeature sketchFeature1 = AskSketchFeatureByName(sketchName);
            features1[0] = sketchFeature1;
            NXOpen.DisplayableObject nullNXOpen_DisplayableObject = null;
            NXOpen.CurveFeatureRule curveFeatureRule1;
            curveFeatureRule1 = workPart.ScRuleFactory.CreateRuleCurveFeature(features1, nullNXOpen_DisplayableObject, selectionIntentRuleOptions1);

            selectionIntentRuleOptions1.Dispose();

            section1.AllowSelfIntersection(true);

            section1.AllowDegenerateCurves(false);

            NXOpen.SelectionIntentRule[] rules1 = { curveFeatureRule1 };

            NXOpen.NXObject nullNXOpen_NXObject = null;

            NXOpen.Point3d helpPoint1 = new Point3d(0, 0, 0);
            section1.AddToSection(rules1, nullNXOpen_NXObject, nullNXOpen_NXObject, nullNXOpen_NXObject, helpPoint1, NXOpen.Section.Mode.Create, false);

            extrudeBuilder1.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Create;

            NXOpen.Body[] targetBodies6 = new NXOpen.Body[1];
            targetBodies6[0] = nullNXOpen_Body;
            extrudeBuilder1.BooleanOperation.SetTargetBodies(targetBodies6);

            NXOpen.Body[] targetBodies7 = new NXOpen.Body[0];
            extrudeBuilder1.BooleanOperation.SetTargetBodies(targetBodies7);

            extrudeBuilder1.ParentFeatureInternal = false;

            NXOpen.Features.Feature extrudeFeature;
            extrudeFeature = extrudeBuilder1.CommitFeature();

            NXOpen.Expression expression2 = extrudeBuilder1.Limits.StartExtend.Value;
            NXOpen.Expression expression3 = extrudeBuilder1.Limits.EndExtend.Value;
            extrudeBuilder1.Destroy();

            workPart.Expressions.Delete(expression1);

            NXOpen.DisplayModification displayModification1;
            displayModification1 = theSession.DisplayManager.NewDisplayModification();

            displayModification1.ApplyToAllFaces = true;

            displayModification1.ApplyToOwningParts = false;

            displayModification1.NewColor = 184;

            displayModification1.NewWidth = NXOpen.DisplayableObject.ObjectWidth.Two;

            NXOpen.DisplayableObject[] objects1 = new NXOpen.DisplayableObject[1];
            NXOpen.Body body1 = extrudeFeature.GetBodies().First();
            objects1[0] = body1;
            displayModification1.Apply(objects1);

            displayModification1.Dispose();
        }

        private SketchFeature AskSketchFeatureByName(string sketchName)
        {
            Session session = Session.GetSession();
            Part workPart = session.Parts.Work;
            Sketch targetSektch = null;

            //System.Diagnostics.Debugger.Launch();

            foreach (var obj in workPart.Sketches)
            {
                if (obj is not Sketch sketch)
                {
                    continue;
                }
                else if (sketch.Name.Equals(sketchName, StringComparison.OrdinalIgnoreCase))
                {
                    targetSektch = sketch;
                    break;
                }
            }

            foreach (Feature feat in workPart.Features)
            {
                if (feat is SketchFeature sketchFeature &&
                    sketchFeature.Sketch == targetSektch)
                {
                    return sketchFeature;
                }
            }

            return null;
        }

        public void ProfileGenerateManager(ComponentCreationConfig config)
        {
            config.WaveLinkerObject = CreateWaveGeometryLinker(config);            
            MakeSketchFromWaveLinker(config);
        }

        public void MakeSketchFromWaveLinker(ComponentCreationConfig config)
        {
            string sketchName = "MAIN";
            NXOpen.Session theSession = NXOpen.Session.GetSession();
            NXOpen.Part workPart = theSession.Parts.Work;
            NXOpen.Part displayPart = theSession.Parts.Display;
            // ----------------------------------------------
            //   Menu: Insert->Sketch
            // ----------------------------------------------            

            theSession.BeginTaskEnvironment();

            // ----------------------------------------------
            //   Menu: Application->Document->PMI
            // ----------------------------------------------

            NXOpen.Sketch nullNXOpen_Sketch = null;
            NXOpen.SketchInPlaceBuilder sketchInPlaceBuilder1;
            sketchInPlaceBuilder1 = workPart.Sketches.CreateSketchInPlaceBuilder2(nullNXOpen_Sketch);

            NXOpen.Point3d origin1 = new NXOpen.Point3d(0.0, 0.0, 0.0);
            NXOpen.Vector3d normal1 = new NXOpen.Vector3d(0.0, 0.0, 1.0);
            NXOpen.Plane plane1;
            plane1 = workPart.Planes.CreatePlane(origin1, normal1, NXOpen.SmartObject.UpdateOption.WithinModeling);

            sketchInPlaceBuilder1.PlaneReference = plane1;

            NXOpen.Unit unit1 = ((NXOpen.Unit)workPart.UnitCollection.FindObject("MilliMeter"));
            NXOpen.Expression expression1;
            expression1 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);

            NXOpen.Expression expression2;
            expression2 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);

            NXOpen.SketchAlongPathBuilder sketchAlongPathBuilder1;
            sketchAlongPathBuilder1 = workPart.Sketches.CreateSketchAlongPathBuilder(nullNXOpen_Sketch);

            NXOpen.SimpleSketchInPlaceBuilder simpleSketchInPlaceBuilder1;
            simpleSketchInPlaceBuilder1 = workPart.Sketches.CreateSimpleSketchInPlaceBuilder();

            sketchAlongPathBuilder1.PlaneLocation.Expression.SetFormula("0");

            simpleSketchInPlaceBuilder1.UseWorkPartOrigin = false;
            
            NXOpen.DatumAxis datumAxis1 = AskXDatumAxis();
            NXOpen.Direction direction1;
            direction1 = workPart.Directions.CreateDirection(datumAxis1, NXOpen.Sense.Forward, NXOpen.SmartObject.UpdateOption.WithinModeling);
            
            NXOpen.DatumPlane datumPlane1 = AskXYDatumPlane();
            
            NXOpen.Features.DatumCsys datumCsys1 = AskDatumCsys();
            
            NXOpen.Point point1 = AskDatumPoint();
            NXOpen.Xform xform1;
            xform1 = workPart.Xforms.CreateXformByPlaneXDirPoint(datumPlane1, direction1, point1, NXOpen.SmartObject.UpdateOption.WithinModeling, 0.625, false, false);

            NXOpen.CartesianCoordinateSystem cartesianCoordinateSystem1;
            cartesianCoordinateSystem1 = workPart.CoordinateSystems.CreateCoordinateSystem(xform1, NXOpen.SmartObject.UpdateOption.WithinModeling);

            simpleSketchInPlaceBuilder1.CoordinateSystem = cartesianCoordinateSystem1;

            simpleSketchInPlaceBuilder1.HorizontalReference.Value = datumAxis1;

            NXOpen.Point point2;
            point2 = simpleSketchInPlaceBuilder1.SketchOrigin;

            simpleSketchInPlaceBuilder1.SketchOrigin = point2;

            NXOpen.Xform nullNXOpen_Xform = null;
            NXOpen.Point point3;
            point3 = workPart.Points.CreatePoint(point1, nullNXOpen_Xform, NXOpen.SmartObject.UpdateOption.WithinModeling);

            theSession.Preferences.Sketch.CreateInferredConstraints = false;

            theSession.Preferences.Sketch.ContinuousAutoDimensioning = false;

            theSession.Preferences.Sketch.DimensionLabel = NXOpen.Preferences.SketchPreferences.DimensionLabelType.Expression;

            theSession.Preferences.Sketch.TextSizeFixed = false;

            theSession.Preferences.Sketch.FixedTextSize = 3.0;

            theSession.Preferences.Sketch.DisplayParenthesesOnReferenceDimensions = true;

            theSession.Preferences.Sketch.DisplayReferenceGeometry = false;

            theSession.Preferences.Sketch.DisplayShadedRegions = true;

            theSession.Preferences.Sketch.FindMovableObjects = true;

            theSession.Preferences.Sketch.ConstraintSymbolSize = 3.0;

            theSession.Preferences.Sketch.DisplayObjectColor = false;

            theSession.Preferences.Sketch.DisplayObjectName = true;

            theSession.Preferences.Sketch.EditDimensionOnCreation = true;

            theSession.Preferences.Sketch.CreateDimensionForTypedValues = true;

            NXOpen.NXObject nXObject1;
            nXObject1 = simpleSketchInPlaceBuilder1.Commit();

            NXOpen.Sketch sketch1 = ((NXOpen.Sketch)nXObject1);
            NXOpen.Features.Feature feature1;
            feature1 = sketch1.Feature;

            sketch1.Activate(NXOpen.Sketch.ViewReorient.True);

            theSession.Preferences.Sketch.FindMovableObjects = true;

            NXOpen.SketchFindMovableObjectsBuilder sketchFindMovableObjectsBuilder1;
            sketchFindMovableObjectsBuilder1 = workPart.Sketches.CreateFindMovableObjectsBuilder();

            NXOpen.NXObject nXObject2;
            nXObject2 = sketchFindMovableObjectsBuilder1.Commit();

            sketchFindMovableObjectsBuilder1.Destroy();

            sketchInPlaceBuilder1.Destroy();

            sketchAlongPathBuilder1.Destroy();

            simpleSketchInPlaceBuilder1.Destroy();

            workPart.Points.DeletePoint(point3);

            try
            {
                // Expression is still in use.
                workPart.Expressions.Delete(expression2);
            }
            catch (NXException ex)
            {
                ex.AssertErrorCode(1050029);
            }

            try
            {
                // Expression is still in use.
                workPart.Expressions.Delete(expression1);
            }
            catch (NXException ex)
            {
                ex.AssertErrorCode(1050029);
            }

            plane1.DestroyPlane();

            theSession.ActiveSketch.SetName(sketchName);

            // ----------------------------------------------
            //   Menu: Insert->Associative Curve->Project Curve...
            // ----------------------------------------------            

            NXOpen.Features.Feature nullNXOpen_Features_Feature = null;
            NXOpen.SketchProjectBuilder sketchProjectBuilder1;
            sketchProjectBuilder1 = workPart.Sketches.CreateProjectBuilder(nullNXOpen_Features_Feature);

            sketchProjectBuilder1.Tolerance = 0.001;

            sketchProjectBuilder1.Section.PrepareMappingData();


            sketchProjectBuilder1.Section.DistanceTolerance = 0.001;

            sketchProjectBuilder1.Section.ChainingTolerance = 0.00095;

            sketchProjectBuilder1.Section.SetAllowedEntityTypes(NXOpen.Section.AllowTypes.CurvesAndPoints);

            NXOpen.SelectionIntentRuleOptions selectionIntentRuleOptions1;
            selectionIntentRuleOptions1 = workPart.ScRuleFactory.CreateRuleOptions();

            selectionIntentRuleOptions1.SetSelectedFromInactive(false);

            NXOpen.Face[] facesOfFeatures1 = new NXOpen.Face[1];
            ExtractFace extractFace1 = config.WaveLinkerObject as ExtractFace;
            NXOpen.Face face1 = extractFace1.GetFaces().First();
            facesOfFeatures1[0] = face1;
            NXOpen.EdgeBoundaryRule edgeBoundaryRule1;
            edgeBoundaryRule1 = workPart.ScRuleFactory.CreateRuleEdgeBoundary(facesOfFeatures1, selectionIntentRuleOptions1);

            selectionIntentRuleOptions1.Dispose();
            sketchProjectBuilder1.Section.AllowSelfIntersection(true);

            sketchProjectBuilder1.Section.AllowDegenerateCurves(false);

            NXOpen.SelectionIntentRule[] rules1 = new NXOpen.SelectionIntentRule[1];
            rules1[0] = edgeBoundaryRule1;
            NXOpen.NXObject nullNXOpen_NXObject = null;            
            
            UFSession ufs = UFSession.GetUFSession();
            double[] bBox = new double[6];
            ufs.Modl.AskBoundingBox(face1.Tag, bBox);
            Point3d helpPoint1 = new Point3d(bBox[0], bBox[1], bBox[2]);

            sketchProjectBuilder1.Section.AddToSection(rules1, face1, nullNXOpen_NXObject, nullNXOpen_NXObject, helpPoint1, NXOpen.Section.Mode.Create, false);

            sketchProjectBuilder1.Section.CleanMappingData();

            sketchProjectBuilder1.Section.CleanMappingData();

            sketchProjectBuilder1.ProjectAsDumbFixedCurves = false;

            NXOpen.NXObject nXObject3;
            nXObject3 = sketchProjectBuilder1.Commit();

            NXOpen.SketchFindMovableObjectsBuilder sketchFindMovableObjectsBuilder2;
            sketchFindMovableObjectsBuilder2 = workPart.Sketches.CreateFindMovableObjectsBuilder();

            NXOpen.NXObject nXObject4;
            nXObject4 = sketchFindMovableObjectsBuilder2.Commit();

            sketchFindMovableObjectsBuilder2.Destroy();

            sketchProjectBuilder1.Destroy();

            // ----------------------------------------------
            //   Menu: Task->Finish Sketch
            // ----------------------------------------------
            NXOpen.SketchWorkRegionBuilder sketchWorkRegionBuilder1;
            sketchWorkRegionBuilder1 = workPart.Sketches.CreateWorkRegionBuilder();

            sketchWorkRegionBuilder1.Scope = NXOpen.SketchWorkRegionBuilder.ScopeType.EntireSketch;

            NXOpen.NXObject nXObject5;
            nXObject5 = sketchWorkRegionBuilder1.Commit();

            sketchWorkRegionBuilder1.Destroy();

            theSession.ActiveSketch.CalculateStatus();

            theSession.Preferences.Sketch.SectionView = false;

            theSession.ActiveSketch.Deactivate(NXOpen.Sketch.ViewReorient.True, NXOpen.Sketch.UpdateLevel.Model);

            theSession.DeleteUndoMarksSetInTaskEnvironment();

            // ----------------------------------------------
            //   Menu: Application->Document->PMI
            // ----------------------------------------------
            theSession.EndTaskEnvironment();
        }

        public NXObject CreateWaveGeometryLinker(ComponentCreationConfig config)
        {
            string linkerName = "CUTTING_FACE";
            NXOpen.Session theSession = NXOpen.Session.GetSession();
            NXOpen.Part workPart = theSession.Parts.Work;
            NXOpen.Part displayPart = theSession.Parts.Display;
            // ----------------------------------------------
            //   Menu: Insert->Associative Copy->WAVE Geometry Linker...
            // ----------------------------------------------                       

            NXOpen.Features.Feature nullNXOpen_Features_Feature = null;
            NXOpen.Features.WaveLinkBuilder waveLinkBuilder1;
            waveLinkBuilder1 = workPart.BaseFeatures.CreateWaveLinkBuilder(nullNXOpen_Features_Feature);

            NXOpen.Features.WaveDatumBuilder waveDatumBuilder1;
            waveDatumBuilder1 = waveLinkBuilder1.WaveDatumBuilder;

            NXOpen.Features.CompositeCurveBuilder compositeCurveBuilder1;
            compositeCurveBuilder1 = waveLinkBuilder1.CompositeCurveBuilder;

            NXOpen.Features.WaveSketchBuilder waveSketchBuilder1;
            waveSketchBuilder1 = waveLinkBuilder1.WaveSketchBuilder;

            NXOpen.Features.WaveRoutingBuilder waveRoutingBuilder1;
            waveRoutingBuilder1 = waveLinkBuilder1.WaveRoutingBuilder;

            NXOpen.Features.WavePointBuilder wavePointBuilder1;
            wavePointBuilder1 = waveLinkBuilder1.WavePointBuilder;

            NXOpen.Features.ExtractFaceBuilder extractFaceBuilder1;
            extractFaceBuilder1 = waveLinkBuilder1.ExtractFaceBuilder;

            NXOpen.Features.MirrorBodyBuilder mirrorBodyBuilder1;
            mirrorBodyBuilder1 = waveLinkBuilder1.MirrorBodyBuilder;

            NXOpen.GeometricUtilities.CurveFitData curveFitData1;
            curveFitData1 = compositeCurveBuilder1.CurveFitData;

            curveFitData1.Tolerance = 0.001;

            curveFitData1.AngleTolerance = 0.01;

            NXOpen.Section section1;
            section1 = compositeCurveBuilder1.Section;

            section1.SetAllowRefCrvs(false);

            extractFaceBuilder1.FaceOption = NXOpen.Features.ExtractFaceBuilder.FaceOptionType.FaceChain;

            extractFaceBuilder1.FaceOption = NXOpen.Features.ExtractFaceBuilder.FaceOptionType.FaceChain;

            extractFaceBuilder1.AngleTolerance = 45.0;

            waveDatumBuilder1.DisplayScale = 2.0;

            extractFaceBuilder1.ParentPart = NXOpen.Features.ExtractFaceBuilder.ParentPartType.OtherPart;

            mirrorBodyBuilder1.ParentPartType = NXOpen.Features.MirrorBodyBuilder.ParentPart.OtherPart;

            compositeCurveBuilder1.Section.DistanceTolerance = 0.001;

            compositeCurveBuilder1.Section.ChainingTolerance = 0.00095;

            compositeCurveBuilder1.Section.AngleTolerance = 0.01;

            compositeCurveBuilder1.Section.DistanceTolerance = 0.001;

            compositeCurveBuilder1.Section.ChainingTolerance = 0.00095;

            compositeCurveBuilder1.Associative = true;

            compositeCurveBuilder1.MakePositionIndependent = false;

            compositeCurveBuilder1.FixAtCurrentTimestamp = false;

            compositeCurveBuilder1.HideOriginal = false;

            compositeCurveBuilder1.InheritDisplayProperties = false;

            compositeCurveBuilder1.JoinOption = NXOpen.Features.CompositeCurveBuilder.JoinMethod.No;

            compositeCurveBuilder1.Tolerance = 0.001;

            NXOpen.Section section2;
            section2 = compositeCurveBuilder1.Section;

            NXOpen.GeometricUtilities.CurveFitData curveFitData2;
            curveFitData2 = compositeCurveBuilder1.CurveFitData;

            extractFaceBuilder1.InheritMaterial = true;

            waveLinkBuilder1.InheritMaterial = true;

            mirrorBodyBuilder1.InheritMaterial = true;

            section2.SetAllowedEntityTypes(NXOpen.Section.AllowTypes.CurvesAndPoints);

            waveLinkBuilder1.Type = NXOpen.Features.WaveLinkBuilder.Types.BodyLink;

            extractFaceBuilder1.Associative = true;

            extractFaceBuilder1.MakePositionIndependent = false;

            extractFaceBuilder1.FixAtCurrentTimestamp = false;

            extractFaceBuilder1.HideOriginal = false;

            extractFaceBuilder1.InheritDisplayProperties = false;

            NXOpen.ScCollector scCollector1;
            scCollector1 = extractFaceBuilder1.ExtractBodyCollector;

            extractFaceBuilder1.CopyThreads = true;

            extractFaceBuilder1.FeatureOption = NXOpen.Features.ExtractFaceBuilder.FeatureOptionType.OneFeatureForAllBodies;

            extractFaceBuilder1.CopyGroups = false;

            NXOpen.SelectionIntentRuleOptions selectionIntentRuleOptions1;
            selectionIntentRuleOptions1 = workPart.ScRuleFactory.CreateRuleOptions();

            selectionIntentRuleOptions1.SetSelectedFromInactive(false);

            NXOpen.Body[] bodies1 = new NXOpen.Body[1];
            //NXOpen.Assemblies.Component component1 = ((NXOpen.Assemblies.Component)displayPart.ComponentAssembly.RootComponent.FindObject("COMPONENT CSRS40-0000_32T_&_15T_STRIPLAYOUT-V00 1"));
            //NXOpen.Body body1 = ((NXOpen.Body)component1.FindObject("PROTO#.Bodies|BOUNDED_PLANE(94)"));

            TaggedObject sheetTagObj = config.SheetObject;
            Body sheetBody = sheetTagObj as Body;
            bodies1[0] = sheetBody;
            NXOpen.BodyDumbRule bodyDumbRule1 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies1, true, selectionIntentRuleOptions1);

            selectionIntentRuleOptions1.Dispose();
            NXOpen.SelectionIntentRule[] rules1 = new NXOpen.SelectionIntentRule[1];
            rules1[0] = bodyDumbRule1;
            scCollector1.ReplaceRules(rules1, false);

            NXOpen.NXObject linkerObject;
            linkerObject = waveLinkBuilder1.Commit();

            linkerObject.SetName(linkerName);

            waveLinkBuilder1.Destroy();

            return linkerObject;
        }

        

        public void MakeSketchProjectCurve(ComponentCreationConfig config)
        {
            NXOpen.Session theSession = NXOpen.Session.GetSession();
            NXOpen.Part workPart = theSession.Parts.Work;
            NXOpen.Part displayPart = theSession.Parts.Display;
            // ----------------------------------------------
            //   Menu: Insert->Sketch
            // ----------------------------------------------            

            NXOpen.Sketch nullNXOpen_Sketch = null;
            NXOpen.SketchInPlaceBuilder sketchInPlaceBuilder1;
            sketchInPlaceBuilder1 = workPart.Sketches.CreateSketchInPlaceBuilder2(nullNXOpen_Sketch);

            NXOpen.Point3d origin1 = new NXOpen.Point3d(0.0, 0.0, 0.0);
            NXOpen.Vector3d normal1 = new NXOpen.Vector3d(0.0, 0.0, 1.0);
            NXOpen.Plane plane1;
            plane1 = workPart.Planes.CreatePlane(origin1, normal1, NXOpen.SmartObject.UpdateOption.WithinModeling);

            sketchInPlaceBuilder1.PlaneReference = plane1;

            NXOpen.Unit unit1 = ((NXOpen.Unit)workPart.UnitCollection.FindObject("MilliMeter"));
            NXOpen.Expression expression1;
            expression1 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);

            NXOpen.Expression expression2;
            expression2 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);

            NXOpen.SketchAlongPathBuilder sketchAlongPathBuilder1;
            sketchAlongPathBuilder1 = workPart.Sketches.CreateSketchAlongPathBuilder(nullNXOpen_Sketch);

            NXOpen.SimpleSketchInPlaceBuilder simpleSketchInPlaceBuilder1;
            simpleSketchInPlaceBuilder1 = workPart.Sketches.CreateSimpleSketchInPlaceBuilder();

            sketchAlongPathBuilder1.PlaneLocation.Expression.SetFormula("0");

            simpleSketchInPlaceBuilder1.UseWorkPartOrigin = false;

            NXOpen.DatumAxis datumAxis1 = AskXDatumAxis();
            NXOpen.Direction direction1;
            direction1 = workPart.Directions.CreateDirection(datumAxis1, NXOpen.Sense.Forward, NXOpen.SmartObject.UpdateOption.WithinModeling);

            NXOpen.DatumPlane datumPlane1 = AskXYDatumPlane();

            NXOpen.Features.DatumCsys datumCsys1 = AskDatumCsys();
            NXOpen.Point point1 = AskDatumPoint();
            NXOpen.Xform xform1;
            xform1 = workPart.Xforms.CreateXformByPlaneXDirPoint(datumPlane1, direction1, point1, NXOpen.SmartObject.UpdateOption.WithinModeling, 0.625, false, false);

            NXOpen.CartesianCoordinateSystem cartesianCoordinateSystem1;
            cartesianCoordinateSystem1 = workPart.CoordinateSystems.CreateCoordinateSystem(xform1, NXOpen.SmartObject.UpdateOption.WithinModeling);

            simpleSketchInPlaceBuilder1.CoordinateSystem = cartesianCoordinateSystem1;

            simpleSketchInPlaceBuilder1.HorizontalReference.Value = datumAxis1;

            NXOpen.Point point2;
            point2 = simpleSketchInPlaceBuilder1.SketchOrigin;

            simpleSketchInPlaceBuilder1.SketchOrigin = point2;

            NXOpen.Xform nullNXOpen_Xform = null;
            NXOpen.Point point3;
            point3 = workPart.Points.CreatePoint(point1, nullNXOpen_Xform, NXOpen.SmartObject.UpdateOption.WithinModeling);

            theSession.Preferences.Sketch.CreateInferredConstraints = false;

            theSession.Preferences.Sketch.ContinuousAutoDimensioning = false;

            theSession.Preferences.Sketch.DimensionLabel = NXOpen.Preferences.SketchPreferences.DimensionLabelType.Expression;

            theSession.Preferences.Sketch.TextSizeFixed = false;

            theSession.Preferences.Sketch.FixedTextSize = 3.0;

            theSession.Preferences.Sketch.DisplayParenthesesOnReferenceDimensions = true;

            theSession.Preferences.Sketch.DisplayReferenceGeometry = false;

            theSession.Preferences.Sketch.DisplayShadedRegions = true;

            theSession.Preferences.Sketch.FindMovableObjects = true;

            theSession.Preferences.Sketch.ConstraintSymbolSize = 3.0;

            theSession.Preferences.Sketch.DisplayObjectColor = false;

            theSession.Preferences.Sketch.DisplayObjectName = true;

            theSession.Preferences.Sketch.EditDimensionOnCreation = true;

            theSession.Preferences.Sketch.CreateDimensionForTypedValues = true;

            NXOpen.NXObject nXObject1;
            nXObject1 = simpleSketchInPlaceBuilder1.Commit();

            NXOpen.Sketch sketch1 = ((NXOpen.Sketch)nXObject1);
            NXOpen.Features.Feature feature1;
            feature1 = sketch1.Feature;

            sketch1.Activate(NXOpen.Sketch.ViewReorient.True);

            theSession.Preferences.Sketch.FindMovableObjects = true;

            NXOpen.SketchFindMovableObjectsBuilder sketchFindMovableObjectsBuilder1;
            sketchFindMovableObjectsBuilder1 = workPart.Sketches.CreateFindMovableObjectsBuilder();

            NXOpen.NXObject nXObject2;
            nXObject2 = sketchFindMovableObjectsBuilder1.Commit();

            sketchFindMovableObjectsBuilder1.Destroy();

            sketchInPlaceBuilder1.Destroy();

            sketchAlongPathBuilder1.Destroy();

            simpleSketchInPlaceBuilder1.Destroy();

            workPart.Points.DeletePoint(point3);

            try
            {
                // Expression is still in use.
                workPart.Expressions.Delete(expression2);
            }
            catch (NXException ex)
            {
                ex.AssertErrorCode(1050029);
            }

            try
            {
                // Expression is still in use.
                workPart.Expressions.Delete(expression1);
            }
            catch (NXException ex)
            {
                ex.AssertErrorCode(1050029);
            }

            plane1.DestroyPlane();

            theSession.ActiveSketch.SetName("main");

            // ----------------------------------------------
            //   Menu: Insert->Associative Curve->Project Curve...
            // ----------------------------------------------            

            NXOpen.Features.Feature nullNXOpen_Features_Feature = null;
            NXOpen.SketchProjectBuilder sketchProjectBuilder1;
            sketchProjectBuilder1 = workPart.Sketches.CreateProjectBuilder(nullNXOpen_Features_Feature);

            sketchProjectBuilder1.Tolerance = 0.001;

            sketchProjectBuilder1.Section.PrepareMappingData();

            sketchProjectBuilder1.Section.DistanceTolerance = 0.001;

            sketchProjectBuilder1.Section.ChainingTolerance = 0.00095;

            sketchProjectBuilder1.Section.SetAllowedEntityTypes(NXOpen.Section.AllowTypes.CurvesAndPoints);

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

            NXOpen.SelectionIntentRuleOptions selectionIntentRuleOptions1;
            selectionIntentRuleOptions1 = workPart.ScRuleFactory.CreateRuleOptions();

            selectionIntentRuleOptions1.SetSelectedFromInactive(false);

            //NXOpen.Assemblies.Component component1 = ((NXOpen.Assemblies.Component)displayPart.ComponentAssembly.RootComponent.FindObject("COMPONENT CSRS40-0000_32T_&_15T_STRIPLAYOUT-V00 1"));
            //NXOpen.Edge edge1 = ((NXOpen.Edge)component1.FindObject("PROTO#.Features|EXTRUDE(18)|EDGE * 170 EXTRUDE(2) 130 {(55,64.5,1.55)(53.5355339059327,68.0355339059327,1.55)(50,69.5,1.55) EXTRUDE(2)}"));
            TaggedObject sheet = config.SheetObject;
            Body sheetBody = sheet as Body;
            Edge edge1 = sheetBody.GetEdges().First();
            NXOpen.Edge nullNXOpen_Edge = null;
            NXOpen.EdgeTangentRule edgeTangentRule1;
            edgeTangentRule1 = workPart.ScRuleFactory.CreateRuleEdgeTangent(edge1, nullNXOpen_Edge, true, 0.01, false, false, selectionIntentRuleOptions1);

            selectionIntentRuleOptions1.Dispose();
            NXOpen.SelectionIntentRule[] rules1 = new NXOpen.SelectionIntentRule[1];
            rules1[0] = edgeTangentRule1;
            NXOpen.NXObject nullNXOpen_NXObject = null;
            NXOpen.Point3d helpPoint1 = edge1.GetLocations().First().Location;
            section1.AddToSection(rules1, edge1, nullNXOpen_NXObject, nullNXOpen_NXObject, helpPoint1, NXOpen.Section.Mode.Create, false);

            NXOpen.Features.Feature feature2;
            feature2 = compositeCurveBuilder1.CommitCreateOnTheFly();

            NXOpen.GeometricUtilities.WaveLinkRepository waveLinkRepository1;
            waveLinkRepository1 = workPart.CreateWavelinkRepository();

            waveLinkRepository1.SetNonFeatureApplication(false);

            waveLinkRepository1.SetBuilder(sketchProjectBuilder1);

            NXOpen.Features.CompositeCurve compositeCurve1 = ((NXOpen.Features.CompositeCurve)feature2);
            waveLinkRepository1.SetLink(compositeCurve1);

            NXOpen.Features.CompositeCurveBuilder compositeCurveBuilder2;
            compositeCurveBuilder2 = workPart.Features.CreateCompositeCurveBuilder(compositeCurve1);

            compositeCurveBuilder2.Associative = false;

            NXOpen.Features.Feature feature3;
            feature3 = compositeCurveBuilder2.CommitCreateOnTheFly();

            compositeCurveBuilder2.Destroy();

            NXOpen.Features.Feature[] features1 = new NXOpen.Features.Feature[1];
            NXOpen.Features.CompositeCurve compositeCurve2 = ((NXOpen.Features.CompositeCurve)feature3);
            features1[0] = compositeCurve2;
            NXOpen.Features.SketchFeature sketchFeature1 = ((NXOpen.Features.SketchFeature)feature1);
            workPart.Features.ReorderFeature(features1, sketchFeature1, NXOpen.Features.FeatureCollection.ReorderType.Before);

            compositeCurveBuilder1.Destroy();

            NXOpen.SelectionIntentRuleOptions selectionIntentRuleOptions2;
            selectionIntentRuleOptions2 = workPart.ScRuleFactory.CreateRuleOptions();

            selectionIntentRuleOptions2.SetSelectedFromInactive(false);

            NXOpen.Features.Feature[] features2 = new NXOpen.Features.Feature[1];
            features2[0] = compositeCurve2;
            NXOpen.DisplayableObject nullNXOpen_DisplayableObject = null;
            NXOpen.CurveFeatureRule curveFeatureRule1;
            curveFeatureRule1 = workPart.ScRuleFactory.CreateRuleCurveFeature(features2, nullNXOpen_DisplayableObject, selectionIntentRuleOptions2);

            selectionIntentRuleOptions2.Dispose();
            sketchProjectBuilder1.Section.AllowSelfIntersection(true);

            sketchProjectBuilder1.Section.AllowDegenerateCurves(false);

            NXOpen.SelectionIntentRule[] rules2 = new NXOpen.SelectionIntentRule[1];
            rules2[0] = curveFeatureRule1;
            //NXOpen.Arc arc1 = ((NXOpen.Arc)compositeCurve2.FindObject("CURVE 1 {5 (63.5355339059328,68.0355339059327,-76)}"));
            NXOpen.Point3d helpPoint2 = edge1.GetLocations().First().Location;
            sketchProjectBuilder1.Section.AddToSection(rules2, edge1, nullNXOpen_NXObject, nullNXOpen_NXObject, helpPoint2, NXOpen.Section.Mode.Create, false);

            sketchProjectBuilder1.Section.CleanMappingData();

            sketchProjectBuilder1.Section.CleanMappingData();

            sketchProjectBuilder1.ProjectAsDumbFixedCurves = false;

            NXOpen.NXObject nXObject3;
            nXObject3 = sketchProjectBuilder1.Commit();

            NXOpen.SketchFindMovableObjectsBuilder sketchFindMovableObjectsBuilder2;
            sketchFindMovableObjectsBuilder2 = workPart.Sketches.CreateFindMovableObjectsBuilder();

            NXOpen.NXObject nXObject4;
            nXObject4 = sketchFindMovableObjectsBuilder2.Commit();

            sketchFindMovableObjectsBuilder2.Destroy();

            sketchProjectBuilder1.Destroy();

            waveLinkRepository1.Destroy();

            // ----------------------------------------------
            //   Menu: Task->Finish Sketch
            // ----------------------------------------------
            NXOpen.SketchWorkRegionBuilder sketchWorkRegionBuilder1;
            sketchWorkRegionBuilder1 = workPart.Sketches.CreateWorkRegionBuilder();

            sketchWorkRegionBuilder1.Scope = NXOpen.SketchWorkRegionBuilder.ScopeType.EntireSketch;

            NXOpen.NXObject nXObject5;
            nXObject5 = sketchWorkRegionBuilder1.Commit();

            sketchWorkRegionBuilder1.Destroy();

            theSession.ActiveSketch.CalculateStatus();

            NXOpen.Features.ProjectCurve projectCurve1 = ((NXOpen.Features.ProjectCurve)nXObject3);
            NXOpen.Section[] section2;
            section2 = projectCurve1.GetSections();

            NXOpen.Section[] section3;
            section3 = compositeCurve2.GetSections();

            theSession.Preferences.Sketch.SectionView = false;

            theSession.ActiveSketch.Deactivate(NXOpen.Sketch.ViewReorient.True, NXOpen.Sketch.UpdateLevel.Model);

            AskSketchFeatureByName("MAIN");
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

        private Point AskDatumPoint()
        {
            Part workPart = Session.GetSession().Parts.Work;
            

            foreach (var obj in workPart.Points)
            {

                if (obj is not Point point)
                {
                    continue;
                }
                else
                {                    
                    Point3d coordinates = point.Coordinates;                    

                    if (coordinates.X == 0.0 &&
                        coordinates.Y == 0.0 &&
                        coordinates.Z == 0.0
                        )
                    {
                        return point;
                    }
                }
            }

            return null;
        }

        private DatumCsys AskDatumCsys()
        {
            Part workPart = Session.GetSession().Parts.Work;                   

            foreach (var obj in workPart.Features)
            {

                if (obj is not DatumCsys datumCsys)
                {
                    continue;
                }
                else
                {
                    var journalIdentifier = datumCsys.JournalIdentifier;
                    Point3d location = datumCsys.Location;                    

                    if (journalIdentifier.Contains("DATUM_CSYS") &&
                        (location.X == 0.0 &&
                        location.Y == 0.0 &&
                        location.Z == 0.0
                        ))
                    {
                        return datumCsys;
                    }
                }
            }
            return null;
        }

        private DatumAxis AskXDatumAxis()
        {
            Part workPart = Session.GetSession().Parts.Work;

            foreach (var obj in workPart.Datums)
            {

                if (obj is not DatumAxis axis)
                {
                    continue;
                }
                else
                {
                    var journalIdentifier = axis.JournalIdentifier;
                    Vector3d direction = axis.Direction;
                    if (journalIdentifier.Contains("X axis") &&
                        (direction.X == 1.0 &&
                        direction.Y == 0.0 &&
                        direction.Z == 0.0
                        ))
                    {
                        return axis;
                    }
                }
            }

            return null;
        }

        private void SaveNCloseComponent(Part workPart)
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
