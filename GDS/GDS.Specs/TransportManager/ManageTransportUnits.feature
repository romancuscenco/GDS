Feature: ManageTransportUnits
	In order to effectively manage the GDS Transport Park
	As a Transport Manager 
	I want to be able to view, add and retire GDS Transport Units

@Transport_Manager_User
Scenario: Go to "Manage Transport" screen after a successful login
	Given I am logged into GDS as a Transport Manager User
	And I am in the "MyAccount" screen	
	When I click on "Manage Transport" link
	Then I should be redirected to "Manage Transport" screen


@Transport_Manager_User
Scenario: View the list with all transports
	Given I am on the "Manage Transport" screen
	When I request the list of <Status_desc> Transports
	Then I should see the following list
		| SerialNumber | Status_desc  |
		| P-348-A      | Active       |
		| S-232-G      | Active       |
		| T-282-D      | Active       |
		| V-517-U      | Retired      |
		| G-135-N      | Retired      |

		
@Transport_Manager_User
Scenario: Adding new transport to the active list
	Given I am on the "Manage Transport" screen
	When I send the request of adding the following transport
		| SerialNumber |		
		| C-992-H      |
	Then I should get a valid <guid> as a response


@Transport_Manager_User
Scenario: Retiring an active transport
	Given I am on the "Manage Transport" screen
	When I send the request of adding the following transport
		| SerialNumber |		
		| C-992-H      |
	Then I should get a valid Guid as a response

 	
