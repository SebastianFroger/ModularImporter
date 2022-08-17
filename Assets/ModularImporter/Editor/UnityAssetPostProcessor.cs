using UnityEditor;
using UnityEngine;

namespace ModularImporter
{
    public class UnityAssetPostProcessor : AssetPostprocessor
    {
        ////////////////////////////////// PREPROCESS ASSET //////////////////////////////////

        SequenceProcessor processor;

        //NOTE: passes assetImporter of asset type (FBXImporter, TextureImporter...)
        void OnPreprocessAsset()
        {
            // processor = new SequenceProcessor(context);
            SequenceProcessor.Run(ImportStep.OnPreprocessAsset, context, assetImporter);
        }


        ////////////////////////////////// PREPROCESS TYPED //////////////////////////////////

        void OnPreprocessModel()
        {
            SequenceProcessor.Run(ImportStep.OnPreprocessType, context, assetImporter);
        }

        void OnPreprocessTexture()
        {
            SequenceProcessor.Run(ImportStep.OnPreprocessType, context, assetImporter);
        }


        ////////////////////////////////// POSTPROCESS TYPED //////////////////////////////////

        void OnPostprocessModel(GameObject gameObject)
        {
            SequenceProcessor.Run(ImportStep.OnPostprocessType, context, assetImporter, gameObject);
        }

        void OnPostprocessTexture(Texture2D texture)
        {
            SequenceProcessor.Run(ImportStep.OnPostprocessType, context, assetImporter, texture);
        }

        // void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        // {
        //     SequenceProcessor.Run(ImportStep.OnPostprocessType, context, assetImporter, texture);
        // }
    }
}