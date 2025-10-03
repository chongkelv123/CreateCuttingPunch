using CreateCuttingPunch.Model;
using NXOpen;
using NXOpen.UF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NXOpen.Selection;

namespace CreateCuttingPunch.Services
{
    public class SelectionServices
    {
        private readonly SelectionModel _selectionModel;

        public SelectionServices()
        {
            _selectionModel = new SelectionModel();
        }

        private Selection.MaskTriple GetSheetBodyMask =>
            new Selection.MaskTriple(
                UFConstants.UF_solid_type,
                UFConstants.UF_solid_body_subtype,
                UFConstants.UF_UI_SEL_FEATURE_SHEET_BODY); // Or UF_solid_type if needed

        private Selection.MaskTriple GetSketchMask => new Selection.MaskTriple(
                UFConstants.UF_sketch_type,
                UFConstants.UF_all_subtype,
                0); // Not a solid body

        private Selection.MaskTriple GetDatumMask => new Selection.MaskTriple(
            UFConstants.UF_datum_plane_type,
            UFConstants.UF_all_subtype,
            0);

        public SelectionDatumModel DatumSelection()
        {
            UI ui = UI.GetUI();
            var selectionManager = ui.SelectionManager;
            Selection.SelectionScope scope = Selection.SelectionScope.AnyInAssembly;
            string message = "Select a datum for the punch creation";
            string title = "Select Datum";

            // Create an array to hold the masks
            Selection.MaskTriple[] maskArray = new Selection.MaskTriple[] { GetDatumMask };

            Selection.SelectionAction action = Selection.SelectionAction.ClearAndEnableSpecific;
            bool includeFeatures = false;
            bool keepHighlighted = false;

            TaggedObject outObject;
            Point3d cursor;

            Response response = selectionManager.SelectTaggedObject(
                message,
                title,
                scope,
                action,
                includeFeatures,
                keepHighlighted,
                maskArray,
                out outObject,
                out cursor);

            var result = ProcessTaggedObjectToSelectionDatumModel(outObject);

            return result;
        }

        public SelectionModel Selections()
        {
            UI ui = UI.GetUI();
            var selectionManager = ui.SelectionManager;
            Selection.SelectionScope scope = Selection.SelectionScope.AnyInAssembly;
            string message = "Select a sketch or face for the punch creation";
            string title = "Select Sketch or Face";

            // Create an array to hold the masks
            Selection.MaskTriple[] maskArray = new Selection.MaskTriple[] { GetSheetBodyMask, GetSketchMask };

            Selection.SelectionAction action = Selection.SelectionAction.ClearAndEnableSpecific;
            bool includeFeatures = false;
            bool keepHighlighted = false;

            TaggedObject outObject;
            Point3d cursor;

            Response response = selectionManager.SelectTaggedObject(
                message,
                title,
                scope,
                action,
                includeFeatures,
                keepHighlighted,
                maskArray,
                out outObject,
                out cursor);

            var result = ProcessTaggedObjectToSelectionModel(outObject);

            return result;
        }
        
        private SelectionDatumModel ProcessTaggedObjectToSelectionDatumModel(TaggedObject obj)
        {
            if (obj is null)
                return new SelectionDatumModel();

            SelectionDatumModel selModel = new SelectionDatumModel();

            if (obj is DatumPlane datumPlane)
            {
                selModel.DatumObject = datumPlane;
            }

            return selModel;
        }


        private SelectionModel ProcessTaggedObjectToSelectionModel(TaggedObject obj)
        {
            if (obj is null)
                return new SelectionModel();

            SelectionModel selModel = new SelectionModel();

            if (obj is Body body)
            {
                if (body.IsSheetBody)
                {
                    selModel.SheetBodyObject.Add(body);                    
                }
            }

            if (obj is Sketch sketch)
            {
                selModel.SketchObject.Add(sketch);                
            }

            return selModel;
        }
    }
}
