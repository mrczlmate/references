"use strict"

let connection = null

setupSignalR()

function setupSignalR() {
  connection = new signalR.HubConnectionBuilder()
     .withUrl("http://localhost:33074/hub")
     .configureLogging(signalR.LogLevel.Information)
     .build()

 connection.on("AuthorCreated", (user, message) => {
  getAuthors()
 })

 connection.on("AuthorDeleted", (user, message) => {
  getAuthors()
 })

 connection.on("AuthorUpdated", (user, message) => {
    getAuthors()
   })

 connection.on("PublisherCreated", (user, message) => {
  getPublishers()
 })

 connection.on("PublisherDeleted", (user, message) => {
  getPublishers()
 })

 connection.on("PublisherUpdated", (user, message) => {
    getPublishers()
   })

 connection.on("CategoryCreated", (user, message) => {
  getCategories()
 })

 connection.on("CategoryDeleted", (user, message) => {
  getCategories()
 })

 connection.on("CategoryUpdated", (user, message) => {
    getCategories()
   })

 connection.on("BookCreated", (user, message) => {
  getBooks()
 })

 connection.on("BookDeleted", (user, message) => {
  getBooks()
 })

 connection.on("BookUpdated", (user, message) => {
    getBooks()
   })

 connection.onclose(async () => {
     await start()
 })
 start()
}

async function start() {
  try {
      await connection.start()
      console.log("SignalR Connected.")
  } catch (err) {
      console.log(err)
      setTimeout(start, 5000)
  }
}

async function loadAll() {
    getAuthors()
    getCategories()
    getPublishers()
    getBooks()
    getStatistics()
}

function showBook(){
    getBooks()
    document.querySelector("#author").style.display = "none"
    document.querySelector("#category").style.display = "none"
    document.querySelector("#publisher").style.display = "none"
    document.querySelector("#statistic").style.display = "none"
    document.querySelector("#book").style.display = "block"
}

function showAuthor(){
    getAuthors()
    document.querySelector("#category").style.display = "none"
    document.querySelector("#publisher").style.display = "none"
    document.querySelector("#statistic").style.display = "none"
    document.querySelector("#book").style.display = "none"
    document.querySelector("#author").style.display = "block"
}

function showCategory(){
    getCategories()
    document.querySelector("#author").style.display = "none"
    document.querySelector("#publisher").style.display = "none"
    document.querySelector("#statistic").style.display = "none"
    document.querySelector("#book").style.display = "none"
    document.querySelector("#category").style.display = "block"
}

function showPublisher(){
    getPublishers()
    document.querySelector("#author").style.display = "none"
    document.querySelector("#category").style.display = "none"
    document.querySelector("#statistic").style.display = "none"
    document.querySelector("#book").style.display = "none"
    document.querySelector("#publisher").style.display = "block"
}

function showStatistic(){
    document.querySelector("#author").style.display = "none"
    document.querySelector("#category").style.display = "none"
    document.querySelector("#publisher").style.display = "none"
    document.querySelector("#book").style.display = "none"
    document.querySelector("#statistic").style.display = "block"
    getStatistics()
}

function showAll() {
    getAuthors()
    getPublishers()
    getCategories()
    getBooks()
    getStatistics()
    document.querySelector("#publisher").style.display = "block"
    document.querySelector("#category").style.display = "block"
    document.querySelector("#author").style.display = "block"
    document.querySelector("#book").style.display = "block"
    document.querySelector("#statistic").style.display = "block"
}