## Project dependencies
- API -> Infrastructure -> Application -> Domain
## Important
- CAUTION: Do not write static method if it is not necessary
## Exception
- Throw error must using CustomException only
## Logging
- Every function has "Logic to handle something important" (eg: create, delete). 
- When you working with 3rd party should Log "Warning", ex: Database, Email, Notification, Read/Write file...
