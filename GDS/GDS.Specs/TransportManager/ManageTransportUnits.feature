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
Scenario: View the list with all active transports
	Given I am on the "Manage Transport" screen
	When I request the list of the first three active Transports
	Then I should see the following list
		| SerialNumber |
		| P-348-A      |
		| S-232-G      |
		| T-282-D      |

		
@Transport_Manager_User
Scenario: Adding new transport to the active list
	Given I am on the "Manage Transport" screen
	When I click the list of the first three active Transports
	Then I should see the following list
		| SerialNumber |
		| P-348-A      |
		| S-232-G      |
		| T-282-D      |

