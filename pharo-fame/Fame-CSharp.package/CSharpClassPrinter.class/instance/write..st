writing
write: aString 
	|i|
	i := indent.
	i to: 1 by: -1 do: [ :index | theStream nextPutAll: ' ' ].
	theStream nextPutAll: aString.