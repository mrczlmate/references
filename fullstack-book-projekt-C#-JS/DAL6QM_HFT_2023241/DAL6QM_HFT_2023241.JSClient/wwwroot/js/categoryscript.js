"use strict"

let categories = []
let categoryIdToUpdate = -1

async function getCategories() {
  await fetch('http://localhost:33074/category')
      .then(x => x.json())
      .then(y => {
          categories = y
          //console.log(categories)
          displayCategory()
      })
}

function displayCategory() {
  document.querySelector('#resultcategory').innerHTML = ""
  categories.forEach(t => {
      document.querySelector('#resultcategory').innerHTML +=
          `<tr>
          <td>${t.categoryId}</td>
          <td>${t.categoryName}</td>
          <td><button class="btn btn-outline-success buttonalign" type="button" onclick="showUpdateCategory(${t.categoryId})">Update</button><button class="btn btn-outline-danger buttonalign" type="button" onclick="removeCategory(${t.categoryId})">Delete</button></td>
          </tr>`
  })
}

function removeCategory(id) {
  fetch('http://localhost:33074/category/' + id, {
      method: 'DELETE',
      headers: { 'Content-Type': 'application/json', },
      body: null })
      .then(response => response)
      .then(data => {
          console.log('Success:', data)
          getCategories()
      })
      .catch((error) => { 
        console.error('Error:', error) 
      })
}

function createCategory() {
  let name = document.querySelector('#categoryname').value
  fetch('http://localhost:33074/category', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json', },
      body: JSON.stringify(
          { categoryName: name })})
      .then(response => response)
      .then(data =>
      {
          console.log('Success:', data)
          getCategories()
      })
      .catch((error) => { 
        console.error('Error:', error)
      })
}

function showUpdateCategory(id){
  document.querySelector("#categorynameUpdate").value = categories.find(t => t["categoryId"] == id)["categoryName"]
  categoryIdToUpdate = id
}

function updateCategory() {
  let name = document.querySelector('#categorynameUpdate').value
  fetch('http://localhost:33074/category', {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json', },
      body: JSON.stringify(
          {
            categoryId: categoryIdToUpdate, 
            categoryName: name 
          })})
      .then(response => response)
      .then(data =>
      {
          console.log('Success:', data)
          getCategories()
      })
      .catch((error) => { 
        console.error('Error:', error)
      })
}