## Root Windows
Prototype drag-able, resize-able windows for representing instance-indepedent data about entities in games and the actions available to them, such as character attributes and special abilities. Developed for the Unity game engine.

## Requirements
This package uses TextMeshProNPM-UnityCSharp, so the Unity Package Manager version of TextMeshPro must be removed using the Unity Package Manager UI in order for this package to work.

## Installation
Initialize an existing Unity project using UnityNPMInit (`npx jordanstudioroot/unitynpminit [project name]` from the root directory) and run `npm install jordanstudioroot/rootwindows-unitycsharp`, or clone/copy the repo into an existing Unity projects Assets folder.

## Tests And Test Coverage
### Test Coverage
![image1](https://www.dropbox.com/s/oyi0iva7i0952cu/code_coverage_7_9_2020.PNG?raw=1)

### TODO
- More unit tests to obtain complete code coverage.
- Automated tests for pointer-based window dragging.
- Automated tests for pointer-based window resizing.
- Automated tests for pointer-based button actions on action bar.
- Component tests window aggregator class.

## Current Features
- Interfaces for representing portrait, description, and attribute data associated with an entity in the project such as a character or object without dependencies on any particular class instance or game object in a centralized **detail view window**.
- Interfaces for associating functions in monobehaviors or classes with clickable actions on an **action bar window**.
- Window dragging.
- Window resizing.
- Instantiating windows on their own or through a central aggregator.

## Planned Features
- Support for closing open windows via direct user input (close button).
- Support for window tabbing.
- More robust support for triggering actions on MonoBehaviors with buttons.
- Sliders.
- Toggles.
- An interface for representing lists of subjects, such as a list of items or characters, without dependencies on any particular class instance or game object in a centralized **subject view window**.

## Criticisms, Suggestions, Pull Requests
Email: [jordannelson@protonmail.com](mailto:jordannelson@protonmail.com)

## Defects
Report on [issues](https://github.com/jordanstudioroot/PROJECT_NAME/issues).
