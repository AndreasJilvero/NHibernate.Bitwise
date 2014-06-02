# NHibernate Bitwise #
----------
Some helping criterias to use with NHibernates QueryOver when you want to perform bitwise operations on enums.

## Usage ##
Exact match:

    var users = Session.QueryOver<User>().Where(x => x.Permissions == (Permissions.Read | Permissions.Write).List();

One bit matches:

    var criteria = BitwiseExpression.On<User>(x => x.Permissions).HasBit(Permissions.Read);
	var users = Session.QueryOver<User>().Where(criteria).List();

Any bit matches:

    var criteria = BitwiseExpression.On<User>(x => x.Permissions).HasAny(Permissions.Read, Permissions.Write);
	var users = Session.QueryOver<User>().Where(criteria).List();