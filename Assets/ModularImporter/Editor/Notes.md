# Modular Importer

## TODO

add settings file with assets roodir and filetypes to ignore/include. scriptable object with inspector

- refactor SequenceProcessor
  - create enum for pre/post sorting
  - create main processing method that goes through all steps below
    - get sequence
    - validate
    - preprocess
    - postprocess

create asset object to pass AssetImportContext context and AssetImporter assetImporte around and avoid using import
references in all files???

add exceptionhandling to SequenceProcessor
get sequences in parent dirs and apply all from the top dir down
check types adn sequences are not loaded every time!
update documentation
write git readme

Notes:
add params[] object in interface methods
