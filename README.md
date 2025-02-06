# DoxygenGenerator
A quick way to generate API documentation from inside Unity using [doxygen](https://www.doxygen.nl/index.html), with [![doxygen-awesome-version](https://img.shields.io/badge/jothepro/doxygen--awesome--css-v2.3.4-blue?logo=github&logoColor=white)](https://github.com/jothepro/doxygen-awesome-css) styling. Useful for generating API of your custom packages.

### Usage

1. Move the [`DoxygenGenerator`](unity/DoxygenGenerator) folder into the `Assets` folder within the Unity project. You should have something like:

   ```
   MyProject
     ├── Assets
          └── DoxygenGenerator
                 └── Editor
   ```
2. From the top menu bar in unity, navigate to **Window** > **Doxygen Generator** to open the Doxygen Generator editor window.

   | <img src="image/unity_doxygen_generator_1.png"  height="400"> | <img src="image/unity_doxygen_generator_2.png"  height="400"> |
   | -- | -- |

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

### Additional feature

#### Add website icon

1. Modify the `DoxygenGenerator/Generator.sh` file.
   
   ```diff
   +   # Add logo
   +   LOGO_SOURCE="$FILES_PATH/logo.drawio.svg"
   +   LOGO_DESTINATION="$doxygenGenerator_OUTPUT_DIRECTORY/html/logo.drawio.svg"
   +   
   +   cp -r $LOGO_SOURCE $LOGO_DESTINATION

   # Update Doxyfile parameters
   declare -A map=(
   ```

2. Save your SVG icon at the location `DoxygenGenerator/Files/logo.drawio.svg`.

#### Choosing a layout

There are two layout options. Choose one of them and configure Doxygen accordingly:

- **Base Theme**

  <img src="image/theme-variants-base.drawio.svg"  height="250">

  Modify the `DoxygenGenerator/Files/Doxyfile` file.
  
  ```diff
  HTML_EXTRA_STYLESHEET  = {{DOXYGEN_AWESOME_PATH}}/doxygen-awesome.css \
                           {{DOXYGEN_CUSTOM_PATH}}/custom.css \
  -                        {{DOXYGEN_AWESOME_PATH}}/doxygen-awesome-sidebar-only.css \
  -                        {{DOXYGEN_AWESOME_PATH}}/doxygen-awesome-sidebar-only-darkmode-toggle.css \
                           {{DOXYGEN_CUSTOM_PATH}}/custom-alternative.css
  ```
- **Sidebar-Only Theme** [ DEFAULT ]

  <img src="image/theme-variants-sidebar-only.drawio.svg"  height="250">

### Tested on

- **OS:**
   
   ☑️ Windows    
   ✅ MacOS    
   ☑️ Linux    
   
- **Shell:** `zsh`, `bash`
