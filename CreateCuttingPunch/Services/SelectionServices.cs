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

        private Selection.MaskTriple GetFaceMask => 
            new Selection.MaskTriple (
                UFConstants.UF_face_type,
                UFConstants.UF_all_subtype,                
                UFConstants.UF_UI_SEL_FEATURE_ANY_FACE); // Or UF_solid_type if needed

        private Selection.MaskTriple GetSketchMask => new Selection.MaskTriple(
                UFConstants.UF_sketch_type,
                UFConstants.UF_all_subtype,
                0); // Not a solid body

        public TaggedObject[] Selection()
        {
            UI ui = UI.GetUI();
            var selctionManager = ui.SelectionManager;
            Selection.SelectionScope scope = NXOpen.Selection.SelectionScope.WorkPart;
            string message = "Select a sketch or face for the punch creation";
            string title = "Select Sketch or Face";

            // Mask for selecting any face
            Selection.MaskTriple faceMask = GetFaceMask;

            // Mask for selecting any sketch
            Selection.MaskTriple sketchMask = GetSketchMask;

            // Create an array to hold the masks
            Selection.MaskTriple[] maskArray = new Selection.MaskTriple[] { faceMask, sketchMask };

            Selection.SelectionAction action = NXOpen.Selection.SelectionAction.ClearAndEnableSpecific;
            bool includeFeatures = false;
            bool keepHighlighted = false;
            TaggedObject[] objectArray;

            Selection.Response response = selctionManager.SelectTaggedObjects(
                message,
                title,
                scope,
                action,
                includeFeatures,
                keepHighlighted,
                maskArray,
                out objectArray
                );

            return objectArray;

        }
    }
}
