using UnityEditor;
using UnityEngine;

namespace ModularImporter
{
    public class UnityAssetPostProcessor : AssetPostprocessor
    {
        ////////////////////////////////// PREPROCESS ASSET //////////////////////////////////

        //NOTE: passes assetImporter of asset type (FBXImporter, TextureImporter...)
        void OnPreprocessAsset()
        {
            SequenceProcessor.PreprocessAsset(context, assetImporter, false);
        }


        ////////////////////////////////// PREPROCESS TYPED //////////////////////////////////

        // passes on FBXImporter
        void OnPreprocessModel()
        {
            SequenceProcessor.PreprocessAsset(context, assetImporter, true);
        }

        // passes on TextureImporter
        void OnPreprocessTexture()
        {
            SequenceProcessor.PreprocessAsset(context, assetImporter, true);
        }


        ////////////////////////////////// POSTPROCESS TYPED //////////////////////////////////

        void OnPostprocessModel(GameObject gameObject)
        {
            SequenceProcessor.PostprocessAsset(context, assetImporter, gameObject);
        }

        void OnPostprocessTexture(Texture2D texture)
        {
            SequenceProcessor.PostprocessAsset(context, assetImporter, texture);
        }

        // void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        // {
        //     // TODO: how to handle this. this runs only once after all files are done importing
        //     // NOTE: may be a good place to clear cached data. 
        // }
    }
}