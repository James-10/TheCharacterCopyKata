# The Character Copy Kata (The Kata)
Unit Testing a Character copier

### About
In the interest of better understanding test-doubles and mocking libraries (like NSubstitute), The Kata is a character copier class that reads characters from a source and copies them to a
destination. It must copy and write one character at a time.

To do this a Copier class that takes in a ISource and IDestination. ISource has the methods
char ReadChar(), char[] ReadChars(int count) and IDestination has the methods void WriteChar(char c), void WriteChars(char[] values). The Copier class has methods
method void Copy() and CopyChars(int count) that when called reads from the ISource writes to
IDestination.

The copying and writing is done character at a time until a newline (‘\n’) is encountered. Then the
processing stops without writing the newline. Only the Copier class may exists as a concrete.

### License
This code may not be be distributed or used outside of using this repository for local testing

### Developer
James Ockhuis (ockhuisjames@gmail.com)
