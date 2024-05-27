# ModularImporter

This proof of concept project is an attempt to avoid complex AssetPostProcessing scripts, and create a more reusable and userfriendly import system in unity. It is a visual and modular way of defining the settings and presets, applied to an asset during import. Once a coder has written a module, it can be used by any user through the editor.

By adding an ImportSequence asset file in a project directory, all files in the directory, and subdirectories, will execute the modules referenced into the ImportSequence.
The modules are small generic scripts, that define the changes to apply to the imported file.
The ImportSequence has a filtering step, that can reference modules used to sort what files should be affected during import.

NOTES: 
This is only a proof of concept, and only a few AssetPostProcessing callbacks have been implemented. 
It may not be stable and error prone depending on use of it.


## How to use

- Create a new ImportSequence by Right Click -> Create -> Modular Importer -> New ImportSequence. Place it in the same folder, or parent folder, of the files you want to affect during import. 

NOTE: The ImportSequence file name must end with .ImportSequence. ex. MyTestImport.ImportSequence

![image](https://github.com/SebastianFroger/ModularImporter/assets/43187719/8ffa7edf-8e99-4c79-bba9-ecc7558851d5)

- Add the desired modules to the proper AssetPostProcessing callbacks, depending on the type of file imported. [AssetPostProcessor Documentation](https://docs.unity3d.com/ScriptReference/AssetPostprocessor.html)

![image](https://github.com/SebastianFroger/ModularImporter/assets/43187719/2e3ab8a6-b124-4846-88d9-68c8735a3112)



## Creating new modules

The module class has to use the Serialiable attribute to show the public fields in the inspector window, and implement one of the followinf interfaces.

![image](https://github.com/SebastianFroger/ModularImporter/assets/43187719/79b1b60b-73b5-46ef-9d76-5e60674277bd)

### IImportModule 
![image](https://github.com/SebastianFroger/ModularImporter/assets/43187719/c134fed2-4abd-4626-b074-355c923d8576)

Use the IImportModule interface for modules that are only used to edit the imported files.

### IValidationModule
![image](https://github.com/SebastianFroger/ModularImporter/assets/43187719/4bed7429-a84e-4093-9e1e-d43066c7d7f7)

Use the IValidationModule interface when filtering which files are to be affected by the IImportModule modules.


## Extending the ImportSequences
To run modules during other import steps, simply add more callbacks to the UnityAssetPostProcessor.cs file, and call SequenceProcessor.Run(...)

![image](https://github.com/SebastianFroger/ModularImporter/assets/43187719/3cdab2fa-8d86-48db-a3df-9cf794757210)


## Other use cases for ImportSequences
When making the same changes to multiple files, it can be usefull to create a new ImportSequence, and simply import the files to edit. Remeber to disable or delete the ImportSequence afterwards to avoid reapplying the changes.
