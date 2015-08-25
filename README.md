# pkcs5

Internal name `Rfc2898Crypt`

C# Console application using `Rfc2898DeriveBytes` to generate crypto keys.

## Help

	pkcs
		Generate PKCS #5 (RFC2898) key in base64
		by @SteGriff (stegriff.co.uk)

	USAGE
		pkcs password salt [bytes]

	password
		The password you would like to encrypt into a key

	salt
		This string will be added to the end of 'rfc2898-syrup-' and used as salt
		I recommend you pass in the username here

	bytes
		Optional - number of bytes in output key complexity. Defaults to 16.

-----

By @SteGriff