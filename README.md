# ModularImporter

A visual and modular way of defining the settings and presets, applied to an asset in unity, during import. This is prototype project is an attempt to avoid complex AssetPostProcessing scripts in unity.

By adding an ImportSequence asset file in a project directory, all files in the directory, and subdirectories, will execute the modules referenced into the ImportSequence.
The modules are small generic scripts, that define the changes to apply to the imported file.
The ImportSequence has a filtering step, that can reference modules used to sort what files should be affected during import.
