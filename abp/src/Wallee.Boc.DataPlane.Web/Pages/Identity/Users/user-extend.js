abp.ui.extensions.tableColumns
	.get('identity.user')
	.addContributor(function (columnList) {
		columnList.addTail({ //add as the last column
			title: '用户全称',
			data: 'name',
			orderable: false,
			render: function (data, type, row) {
				if (row.name) {
					return '<strong>' +
						row.name +
						'<strong>';
				} else {
					return '<i class="text-muted">undefined</i>';
				}
			}
		});
	});
