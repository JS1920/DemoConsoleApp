# DemoConsoleApp
Demo Console App


**** Requirements and approach

1. Print all customer with associated Orders.
2. Mark customer as preffered customer with *
3. If this is customer's 5th order send email to associated parties.
4. Don't allow the orders with amount < 0
		-> This has been implemented in 2 ways.
			b. By just skipping it from printing. This has been impletemented by just using the "IsOrderAmountValid" method in if condition inside CustomerOrders method.
			a. By removing any order with negative amount, from the customer's orders list. 
				(During interview, I made a mistake. Which I have resolved now "ValidateCustomerOrders" inside method. 
					By collecting all OrderId's does not match Amount cretieria in a list and after the iteration is done, Removing them from list after iteration.)
