Feature: GetOrderByNumber

Background:
	Given the host is 'http://localhost:5000/api/'
	And the endpoint is 'pedido/{pedido}'
	And the method is 'Get'

@Get @Order @ByNumber
Scenario: Sucess get order by number.
	Given that parameter 'pedido' is '1'
	When calling request
	Then The response is 400