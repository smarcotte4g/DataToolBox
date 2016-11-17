csvScrubber <- function(pathChanged, fileName) {
  wd <- dirname(pathChanged)
  setwd(wd)
  clean <- "Clean_"
  newFileName <- paste(clean,fileName,sep="")
  deleteNoData <- read.csv(fileName, header = TRUE)
  # Delete all columns with no data
  cleanFile <- deleteNoData[!sapply(deleteNoData, function (x) all(is.na(x) | x == ""))]
  write.csv(cleanFile, file = file.path(wd, newFileName), na="", row.names = F)
}