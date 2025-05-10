## Project dependencies
- API (request/response api) -> Infrastructure (external service) -> Application (core business logic/service, core interface) -> Domain (Define entities)
## Important
- CAUTION: Do not write static method if it is not necessary
## Exception
- Throw error must using CustomException only
- Message Error key define by: layer name (pascal case) + . + folder/type name (pascal case) + . + message name (upper snake case). Ex: "Application.DTOs.Not_Found"
## Logging
- Every function has "Logic to handle something important" (eg: create, delete). 
- When you working with 3rd party should Log "Warning", ex: Database, Email, Notification, Read/Write file...
## Valid Request
- Valid request using Data anotation
