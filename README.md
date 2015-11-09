# ImageEncoder
Must take in a bitmap file, and will save as a bmp.

Encryption done by offset, actaul offset is the specified number squared.

Encryption works as follows

  123
  
  456
  
  789
  
with an offset of 2 this becomes
  
  1002003
  
  0000000
  
  0000000
  
  4005006
  
  0000000
  
  0000000
  7008009
and then is translated such that each zero is a random pixel from the original image. This will then be done again with the new image.
