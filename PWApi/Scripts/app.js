var ViewModel = function () {
	var self = this;
	self.transactions = ko.observableArray();
	self.error = ko.observable();

	var userId = 1;

	var clientsUri = '/api/clients/'+userId+'/';
	var transUri = clientsUri + 'trans';//'/api/clients/1/tran'

	function ajaxHelper(uri, method, data) {
		self.error(''); // Clear error message
		return $.ajax({
			type: method,
			url: uri,
			dataType: 'json',
			contentType: 'application/json',
			data: data ? JSON.stringify(data) : null
		}).fail(function (jqXHR, textStatus, errorThrown) {
			self.error(errorThrown);
		});
	}

	function getAllTransactions() {
		ajaxHelper(transUri, 'GET').done(function (data) {
			self.transactions(data);
		});
	}

	// Fetch the initial data.
	getAllTransactions();
};

ko.applyBindings(new ViewModel());