1. Set User ID and Password in IdentityContext
2. Create initial migration for Identity context (Identity.Entities): Add-Migration InitialCreate
3. Push database: Update-Database
4. Push initial migration for DavesList context (DavesList.Entities): Add-Migration InitialCreate
5. Push database: Update-Database
6. Start DavesList.Api
7. Start daves-list-ui -> npm start
8. Add test user paste /addtestuser endpoint in browser: https://localhost:7098/addtestuser
9. Verify credentials bound in daves-list-ui login
