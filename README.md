# NHibernate Bitwise #

Some helping criterias to use with NHibernates QueryOver when you want to perform bitwise operations on enums.

## Usage ##
Exact match:

    var users = Session.QueryOver<User>().Where(x => x.Permissions == (Permissions.Read | Permissions.Write)).List();

One bit matches:

    var criteria = BitwiseExpression.On<User>(x => x.Permissions).HasBit(Permissions.Read);
	var users = Session.QueryOver<User>().Where(criteria).List();

Bit does not match:
	var criteria = BitwiseExpression.On<User>(x => x.Permissions).NotHasBit(Permissions.Full);
	var users = Query(session => session.QueryOver<User>().Where(criteria).List());

Any bit matches:

    var criteria = BitwiseExpression.On<User>(x => x.Permissions).HasAny(Permissions.Read, Permissions.Write);
	var users = Session.QueryOver<User>().Where(criteria).List();
	
Partial match from some flag variable, user has all of the values on the variable:

	CreateUser(Permissions.Read | Permissions.Write | Permissions.Full);
	var permissionValue = Permissions.Write | Permissions.Full;
	var criteria = BitwiseExpression.On<User>(x => x.Permissions).HasBit(permissionValue);
	var users = Query(session => session.QueryOver<User>().Where(criteria).List());
