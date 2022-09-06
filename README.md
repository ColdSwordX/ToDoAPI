
***Overview***

| Name                     | Description                                      | Request body                    | Responds body      |
|--------------------------|--------------------------------------------------|---------------------------------|--------------------|
| GET "/"                  | root, returns a default "Hello World"            |               NONE              |    String value    |
| GET "/todoitems"         | Returns all ToDoItems that are NOT completet     |               NONE              |   List<ToDoItem>   |
| GET "/todoitems/all"     | Returns ALL ToDoItems.                           |               NONE              |   List<ToDoItem>   |
| GET "todoitems/{id}"     | Pulls a single item with the given ID.           |              int ID             |   List<ToDoItem>   |
| POST "todoitems"         | Adds a new ToDoItem and adds the default values. |     ToDo Item (Json format)     | ToDoItem completet |
| PUT "todoitems/{id}      | Updates a single ToDoItem.                       |     ToDo Item (Json format)     |        NONE        |
| DELETE "/todoitems/{id}" | Removes a single ToDoItem by the given ID.       |               NONE              |        NONE        |


**Ressourceses**
https://www.postman.com/
https://www.tablesgenerator.com/

Used as a guide to make the API
https://docs.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio


**Nuget-Pakker**
..* Microsoft.EntityFrameworkCore.InMemory - Version 6.0.8
..* Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore - Version 6.0.8
..* Swashbuckle.AspNetCore - Version 6.2.3


**Testing**
*PostMan*

GET "/"

	Test
		pm.test("Status code is 200", () => {
			pm.expect(pm.response.code).to.eql(200);
		});
		pm.response.to.have.body("Hello World!")

GET "/todoitems"  

	Test
		pm.test("Status code is 200", () => {
			pm.expect(pm.response.code).to.eql(200);
		});
GET "/todoitems/all"

	Test
		pm.test("Status code is 200", () => {
			pm.expect(pm.response.code).to.eql(200);
		});
GET "todoitems/{id}"

	Test
		pm.test("Status code is 200", () => {
			pm.expect(pm.response.code).to.eql(200);
		});
POST "todoitems"

	body
		{
			"name":"walk dog",
			"Description": "Done by 10 o clock",
			"Priority": 2
		}
	Test
		pm.test("Status code is 201", () => {
			pm.expect(pm.response.code).to.eql(201);
		});
		pm.test("Item have been added", function()
		{
			let response = pm.response.json()

			pm.collectionVariables.set("id_Key", response.id);
			pm.expect(response.name).to.eql("walk dog")
		})
PUT "todoitems/{id}

	body
		{
			"name":"walk dog",
			"Description": "Done by 12 o clock",
			"Priority": 0,
			"IsComplete": true
		}
	Test
		pm.test("Status code is 200", () => {
			pm.expect(pm.response.code).to.eql(204);
		});

DELETE "/todoitems/{id}"

	Test
		pm.test("Status code is 200", () => {
			pm.expect(pm.response.code).to.eql(200);
		});
		pm.test("Removed ToDoItem", function()
		{
			let response = pm.response.json()
			pm.expect(response.id).to.eql(pm.collectionVariables.get("id_Key"))
		})