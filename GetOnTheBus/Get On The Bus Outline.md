# Get on the Bus with MassTransit

Building complex systems can often be easier when you break them into smaller services, but how do you reduce the complexity of the coordination between the services? In this discussion, we'll see how you can use an OSS .Net Service Bus, MassTransit, to facilitate building your applications in a distributed architecture.

* What is MassTransit?
* Messaging
	* Async
	* "Issue" Tolerant
	* Reliable Delivery
* Pub/Sub
	* Publishers and Subscribers
	* Styles
		* Broker
		* Bus
* ESB
	* Decoupled
	* Minimal Central Control
	* PtoP
* Caveats
	* No Request/Response
	* Avoid Distributed Transactions
		* In fact, if you want to, you have to use MSMQ
* Simple MassTransit Demo
* Auditing Demo
	* Helps enable Event Sourcing/Reporting Databases
* Error Handling Demo
	* One Approach - YMMV!
* Sagas
	* Long running transactions
	* State Machines
* Other Queues
	* ActiveMQ, ZeroMQ, Azure Queues (experimental)
* Other Clients
	* Javascript and Ruby clients (experimental)
* Other Reading
	* Patterns of Enterprise Application Architecture (http://www.amazon.com/dp/0321127420)
	* Enterprise Integration Patterns (http://www.amazon.com/dp/0321200683)
* Conclusion