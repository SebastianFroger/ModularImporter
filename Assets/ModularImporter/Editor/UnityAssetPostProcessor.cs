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
            processor = new SequenceProcessor(context);
            processor.Run(ImportStep.OnPreprocessAsset, context, assetImporter);
        }


        ////////////////////////////////// PREPROCESS TYPED //////////////////////////////////

        void OnPreprocessModel()
        {
            processor.Run(ImportStep.OnPreprocessType, context, assetImporter);
        }

        void OnPreprocessTexture()
        {
            processor.Run(ImportStep.OnPreprocessType, context, assetImporter);
        }


        ////////////////////////////////// POSTPROCESS TYPED //////////////////////////////////

        void OnPostprocessModel(GameObject gameObject)
        {
            processor.Run(ImportStep.OnPostprocessType, context, assetImporter, gameObject);
        }

        void OnPostprocessTexture(Texture2D texture)
        {
            processor.Run(ImportStep.OnPostprocessType, context, assetImporter, texture);
        }

        // void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        // {
        //     // TODO: how to handle this. this runs only once after all files are done importing
        //     // NOTE: may be a good place to clear cached data. 
        // }
    }
}