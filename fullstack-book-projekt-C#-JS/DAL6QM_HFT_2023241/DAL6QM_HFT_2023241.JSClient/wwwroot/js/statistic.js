"use strict"

async function getStatistics(){
  await getAuthorStatistic()
  await getPublisherLowBook()
  await getSumBook()
  await getCategoryStatistic()
  await getOrderPriceStat()
}

let authorStat = []

async function getAuthorStatistic() {
  await fetch('http://localhost:33074/stat/authorstatistic')
    .then(x => x.json())
    .then(y => {
      authorStat = y
      //console.log(authorStat)
      displayAuthorStatistic()
    })
}

function displayAuthorStatistic() {
  document.querySelector('#resultauthorstat').innerHTML = ""
  authorStat.forEach(t => {
      document.querySelector('#resultauthorstat').innerHTML +=
          `<tr>
          <td>${t.name}</td>
          <td>${t.bookNumber}</td>
          <td>${t.avgPrice} Ft</td>
          </tr>`
  })
}

let publisherLowBookStat = []

async function getPublisherLowBook() {
  await fetch('http://localhost:33074/stat/publisherlowestbook')
    .then(x => x.json())
    .then(y => {
      publisherLowBookStat = y
      //console.log(publisherLowBookStat)
      displayPublisherLowBook()
    })
}

function displayPublisherLowBook() {
  document.querySelector('#resultpublisherlowbookstat').innerHTML = ""
  publisherLowBookStat.forEach(t => {
      document.querySelector('#resultpublisherlowbookstat').innerHTML +=
          `<tr>
          <td>${t.publisherName}</td>
          <td>${t.lowestPrice} Ft</td>
          </tr>`
  })
}

let sumBookStat = []

async function getSumBook() {
  await fetch('http://localhost:33074/stat/sumbookprices')
    .then(x => x.json())
    .then(y => {
      sumBookStat = y
      //console.log(sumBookStat)
      displaySumBook()
    })
}

function displaySumBook() {
  document.querySelector('#resultsumbookstat').innerHTML = ""
  sumBookStat.forEach(t => {
      document.querySelector('#resultsumbookstat').innerHTML +=
          `<tr>
          <td>${t.name}</td>
          <td>${t.sumPrice} Ft</td>
          </tr>`
  })
}

let categoryStat = []

async function getCategoryStatistic() {
  await fetch('http://localhost:33074/stat/categorystatistic')
    .then(x => x.json())
    .then(y => {
      categoryStat = y
      //console.log(categoryStat)
      displayCategoryStatistic()
    })
}

function displayCategoryStatistic() {
  document.querySelector('#resultcategorystat').innerHTML = ""
  categoryStat.forEach(t => {
      document.querySelector('#resultcategorystat').innerHTML +=
          `<tr>
          <td>${t.name}</td>
          <td>${t.bookNumber}</td>
          <td>${t.avgPrice} Ft</td>
          <td>${t.minPrice} Ft</td>
          <td>${t.maxPrice} Ft</td>
          </tr>`
  })
}

let orderPriceStat = []

async function getOrderPriceStat() {
  await fetch('http://localhost:33074/stat/orderbypricebook')
    .then(x => x.json())
    .then(y => {
      orderPriceStat = y
      //console.log(orderPriceStat)
      displayOrderPriceStat()
    })
}

function displayOrderPriceStat() {
  document.querySelector('#resultorderpricestat').innerHTML = ""
  orderPriceStat.forEach(t => {
      document.querySelector('#resultorderpricestat').innerHTML +=
          `<tr>
          <td>${t.publisherName}</td>
          <td>${t.categoryName}</td>
          <td>${t.authorName}</td>
          <td>${t.bookTitle}</td>
          <td>${t.price} Ft</td>
          </tr>`
  })
}