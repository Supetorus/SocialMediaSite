// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.getElementById("btn-show-account-buttons").addEventListener("click", e => {
	let buttons = document.getElementById("account-buttons");
	console.log(getComputedStyle(buttons).getPropertyValue("width"));
	if (parseInt(getComputedStyle(buttons).getPropertyValue("width").slice(0, -2)) > 0){
		buttons.style.width = "0";
		buttons.style.height = "0";
		buttons.style.padding = "0";
		buttons.style.borderWidth = "0";
	}
	else {
		buttons.style.width = "15rem";
		buttons.style.height = "15rem";
		buttons.style.padding = "1rem";
		buttons.style.borderWidth = "1rem";
	}
})