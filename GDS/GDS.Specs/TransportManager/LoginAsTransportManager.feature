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


@Transport_Manager_User
Scenario: Go to "Manage Transport" screen after a successful login
	Given I am logged into GDS as a Transport Manager User
	And I am in the "MyAccount" screen	
	When I click on "Manage Transport" link
	Then I should be redirected to "Manage Transport" screen
