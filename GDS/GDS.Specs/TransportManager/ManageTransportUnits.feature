Feature: ManageTransportUnits
	In order to effectively manage the GDS Transport Park
	As a Transport Manager 
	I want to be able to view, add and retire GDS Transport Units

Background: 
	Given I have the following transports in the system
		| SerialNumber | Status  |
		| P-348-A      | Ready   |
		| S-232-G      | Ready   |
		| T-282-D      | Ready   |
		| V-517-U      | Retired |
		| G-135-N      | Retired |


@Transport_Manager_User
Scenario: View the list of active transports
	When I request the list of Transports that are not retired
	Then I should see the following active transports list
		| SerialNumber | Status  |
		| P-348-A      | Ready   |
		| S-232-G      | Ready   |
		| T-282-D      | Ready   |		

@Transport_Manager_User
Scenario: View the list of retired transports
	When I request the list of Retired Transports
	Then I should see the following retired transports list
		| SerialNumber | Status  |		
		| V-517-U      | Retired |
		| G-135-N      | Retired |

		
@Transport_Manager_User
Scenario: Adding new transport to the active list
	When I send the request of adding the following transport
		| SerialNumber | Status |
		| C-992-H      | Ready  |
	Then I should have the following active transports in the system
		| SerialNumber | Status |
		| P-348-A      | Ready  |
		| S-232-G      | Ready  |
		| T-282-D      | Ready  |
		| C-992-H      | Ready  |		


@Transport_Manager_User
Scenario: Retiring an active transport
	When I send the request of retiring the following transport
		| SerialNumber | Status |
		| T-282-D      | Ready  |
	Then I should have the following retired transports in the system
		| SerialNumber | Status  |		
		| T-282-D      | Retired |
		| V-517-U      | Retired |
		| G-135-N      | Retired |
 	

@Transport_Manager_User
Scenario:  Editing an active transport's details
	When I send the request of editing the following transport's serial number from "T-282-D" to "T-282-DH"		
	Then I should have the following transports in the system
		| SerialNumber | Status  |
		| P-348-A      | Ready   |
		| S-232-G      | Ready   |
		| T-282-DH     | Ready   |
		| V-517-U      | Retired |
		| G-135-N      | Retired |


@Transport_Manager_User
Scenario:  Retiring a transport that is in "Work" state
	When I send the request of retiring a transport that is in Work state
	Then The transport should remain Ready
	And I should get the message "You cannot retire a transport in work state"  
		