var ViewModel = function () {
	var self = this;
	self.clients = ko.observableArray();
	self.error = ko.observable();

	var userId = 1;

	//var clientsUri = '/api/clients/'+userId;
	var clientsUri = '/api/clients/1/tran'

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

	function getAllClients() {
		ajaxHelper(clientsUri, 'GET').done(function (data) {
			self.clients(data);
		});
	}

	// Fetch the initial data.
	getAllClients();
};

ko.applyBindings(new ViewModel());