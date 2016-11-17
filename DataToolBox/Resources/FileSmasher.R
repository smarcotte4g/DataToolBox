FileSmasher <- function(allFiles){

library('plyr')
smashedFiles<- lapply(allFiles, read.csv, header = TRUE)

filePath <- gsub("^(.*/).*","\\1",allFiles[1])


smashedFiles2 <- rbind.fill(smashedFiles)
write.csv(smashedFiles2, file = file.path(filePath, "AllFilesTogether.csv"), na="", row.names = F)
}