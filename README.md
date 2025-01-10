# DoxygenGenerator
A quick way to generate API documentation from inside Unity using [doxygen](https://www.doxygen.nl/index.html), with [doxygen-awesome](https://github.com/jothepro/doxygen-awesome-css) styling. Useful for generating API of your custom packages. Special thanks to [JacobPennock](https://forum.unity.com/members/jacobpennock.53178/) for the original implementation and [Brogrammar](https://forum.unity.com/members/brogrammar.1045220/) for an updated version that works with more modern versions of Unity.

Watch [this tutorial](https://youtu.be/ltJgXJjS_YQ) to get started.

Note that this is a personal utility tool, not a reliably supported package (I mean just look at this shoddy README). I may make changes to the styling or code at any point without warning, so it may be best to fork this project for yourself. But hey, if you _do_ make any valuable additions, contributions are always welcome!

# DoxygenGenerator - Unity command line builder

## Variables

| Variable | Type | Description |
| --- | --- | --- |
| `doxygenGenerator_DOXYGEN_PATH` | string | Doxygen install path |
| `doxygenGenerator_INPUT_DIRECTORY` | string | Directory you would like your API to be generated from |
| `doxygenGenerator_OUTPUT_DIRECTORY` | string | Directory you would like your API to be generated to |
| `doxygenGenerator_PROJECT` | string | Project Settings - Name |
| `doxygenGenerator_SYNOPSIS` | string | Project Settings - Synopsis |
| `doxygenGenerator_VERSION` | string | Project Settings - Version |

## How to use in command line (MacOS & Linux)

```shell
export doxygenGenerator_DOXYGEN_PATH=$(which doxygen)
export doxygenGenerator_INPUT_DIRECTORY=
export doxygenGenerator_OUTPUT_DIRECTORY=
export doxygenGenerator_PROJECT=
export doxygenGenerator_SYNOPSIS=
export doxygenGenerator_VERSION=

$HOME/Applications/2022.3.31f1/Unity.app/Contents/MacOS/Unity \
-projectPath ./ \
-logFile build.log \
-executeMethod DoxygenGenerator.CommandLine.GenerateDocument \
-quit \
-accept-apiupdate \
-batchmode \
-nographics
```

## Command line builder - Independent of Platform

Use `cmd/DoxygenGenerator/Generator.sh`

### Usage

1. Copy the `cmd/DoxygenGenerator` folder into your project directory.
2. Set up the [environment variables](#variables).
3. Run the script `DoxygenGenerator/Generator.sh` to generate the documentation.
