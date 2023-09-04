# Family Tasks

App for managing my family's schedules and making sure things get done.

It's kinda like if a calendar and a todo list had a baby.

## Views

- Calendar
  - View type
    - Monthly
    - Weekly
    - Daily
  - Functionality
    - Drag and drop tasks to change priority
    - Click/tap to toggle task CRUD
    - Toggling and updating Task should ask if update should apply to single occurrence, all occurrences of that task, or all tasks going forward
      - Scope (enum)
        - Single = 0
        - All = 1
        - AllFollowing = 2
  - Task (CRUD)
    - Title
    - Summary (optional)
    - Category (optional)
    - TaskSchedule (pop-over editor)
      - StartDate
      - Asignee (optional)
      - Priority (int)
        - High: 0
        - Medium: 5000 (default)
        - Low: 10000
      - Frequency (enum)
        - Once = 0 (default)
        - Daily = 1
        - Weekly = 2
        - Monthly = 3
        - Yearly = 4
        - Custom = 5
      - HoursOfTheDay (optional, only if custom)
        - Able to select hours that the event will occur
      - DaysOfTheWeek (optional, only if custom)
        - Able to select days of the week the event will occur
      - EndCondition (enum)
        - Never = 0
        - NumberOfOccurrences = 1
        - OnDate = 2
      - NumberOfOccurrences (optional, only if EndCondition == NumberOfOccurrences)
      - EndDate (optional, only if EndCondition == OnDate)
        - Last day that the task will occur
- CRUD Views (settings menu or sidebar)
  - Family Member
    - Name
    - Color (hex code) (select from theme colors)
  - Category
    - Name
    - Color (hex code) (select from theme colors)

## Controllers

There are current 5 API Controllers:
- Calendar
  - For getting events
- Category
  - CRUD for categories
- FamilyMember
  - CRUD for family members
- Task
  - For creating tasks
- TaskOccurrence
  - For interacting with specific task occurrences

## Notes

### Setup

I started from the .NET CLI react template because it lays out and wires up the front and backend for rapid development. I rearranged a little to make it easier to navigate (by default all the server code is in the root). The UI is in [https://github.com/maple-buice/family-tasks/ClientApp. ](https://github.com/maple-buice/family-tasks/tree/main/ClientApp)

You'll need to install [.NET 7](https://dotnet.microsoft.com/en-us/download) and [Node](https://nodejs.org/en)

I'd recommend working in VSCode with the [C# plugin](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) installed.

Everything is set up to just hit the "Run" (or Debug) button in the IDE and it'll spin up the frontend and backend and get you going. The first time you launch it it'll ask you to generate a local development cert. Do that.
