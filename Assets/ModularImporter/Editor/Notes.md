# Modular Importer

## Calling methods from referenced files

- class name must be identical to files name
- modular importer will look for classes by same name in the assembly
- implement IImportModule interface in the modular process file to call the methods

## AssetPostprocessor

- gets called on any file import and passes the filepath to the ModularImportProcessor

## ModularImportProcessor

- looks through the parent directories from the filepath (incl. the filepath directory) and executes the sequence of IImportModule types in the first ModularImportSequence found.

## ModularImportModule

- must implement IImportModule
- is the class/file that will be called in the given sequence applied in the template file

## TODO

add settings file with assets roodir and filetypes to ignore/include. scriptable object with inspector?
