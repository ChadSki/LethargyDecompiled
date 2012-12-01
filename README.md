# Lethargy

## Lethargy Decompiled

Lethargy was always one of my favorite modding tools for its simplicity and effectiveness.  Apparently written in VB targeting .Net 2.0, I have decompiled Lethargy into C# in an attempt to understand its innards.

It's a mess in there, but I'll try to straighten things out.

### Features

* Meta editor: Once the user clicks a tag, a GUI will load that shows all of the tag's information. The user can then edit the tags properties and the map file will be updated automatically.
* Dependency swapper: This device can be used to swap virtually anything in the level with anything else in the level.Once a tag is selected, all of it's references to other tags will be shown. They can be swapped to reference any other tag, or double clicked to be accessed.
* Plugin support: The meta editing GUI is generated by XML plugins. The user can edit these plugins or download new sets for more powerful editing.
* Custom Edition support: Lethargy can open custom edition maps, allowing easier editing without the conversion of header information.

### Examples of usage

* Each tag class has it's own GUI, allowing for very powerful editing to occur
* Swap anything with anything else
* Hundreds of maps, each with thousands of tags, each with hundreds of possible edits to be made, the possibilities are nearly endless

### Important Notes

* Back up your map files! Doing certain things to a map file may cause an exception error, making the map file unusable. I am not responsible for any wrecked maps.
* Make sure the included 'plugins' folder is in the same directory as the 'lethargy.exe' file. If it is not, the meta editor will not function properly.

### Pictures

#### Lethargy's Meta Editor

![Lethargy's Meta Editor](http://i.imgur.com/T6QgE.jpg)

#### Lethargy's Dependency Swapper

![Lethargy's Dependency Swapper](http://i.imgur.com/pKDgg.jpg)
