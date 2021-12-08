# supermarket

Improvements/thoughts:

Add an IOffer interface so that different types of offers can be implemented, e.g. buy A and B and C for X price
Move the creating and processing of offers into its own service so the Checkout class will only be responsible for scanning items and providing the total
With offers in its own service it can be extended to provide more information about the offers applied, e.g. a supermarket receipt might want to provide more detail on 
With the offers service, it should implement an interface to facilitate unit testing of the Checkout class still and allow multiple implementations if required, e.g. offers loaded from a db or different sources