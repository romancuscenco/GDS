Feature: LoginAsTransportManager
	In order to effectively manage the GDS Transport Park
	As a Transport Manager 
	I want to be able to login to GDS app

@Transport_Manager_User
Scenario: Login as Transport Manager
	Given I am on the login screen	
	When I enter username: "SamSmith", password: "Smith" and click "Login"
	Then I should be redirected to "MyAccount" screen
	And the heading should contain "GDS Transport Manager"
