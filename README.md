# unity-extension-boilerplate
Creating a Unity Extension has lots of setup code. This can be used to speed up that process

This supports the following: 

- Custom Class with MenuContextCreation. Project View -> Create -> Custom Class
- Custom Inspector. The Custom class created will have its own inspector instead of showing the default debug view
- Custom Editor Window that selects the Custom Class, reads the class, and manipulates the data. 
 
To read the data from your asset in your Editor Extension, just use the object mLevel. 
