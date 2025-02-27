function patientBtn() {
    let patient_heading = document.getElementById("patient-heading")
    let patient_table = document.getElementById("patient-table")
    let patient_btn = document.getElementById("patient-btn")

    if (patient_heading.style.display === "none" && patient_table.style.display === "none") {
        patient_heading.style.display = "block";
        patient_table.style.display = "block";
        patient_btn.innerText = "Hide details"

    } else {
        patient_heading.style.display = "none";
        patient_table.style.display = "none";
        patient_btn.innerText = "Show details"

    }
}

function docBtn() {
    let doc_heading = document.getElementById("doc-heading")
    let doc_table = document.getElementById("doc-table")

    if (doc_heading.style.display === "none" && doc_table.style.display === "none") {
        doc_heading.style.display = "block";
        doc_table.style.display = "block";
        document.getElementById("doctors-btn").innerHTML = "Hide Details"
        

    } else {
        doc_heading.style.display = "none";
        doc_table.style.display = "none"
        document.getElementById("doctors-btn").innerHTML = "Show Details"

    }

}

function apptBtn() {
    let appt_heading = document.getElementById("appt-heading");
    let appt_table = document.getElementById("appt-table");

    if (appt_heading.style.display === "none" && appt_table.style.display === "none") {
        appt_heading.style.display = "block";
        appt_table.style.display = "block";
        document.getElementById("appt-btn").innerHTML = "Hide Details"

    } else {
        appt_heading.style.display = "none";
        appt_table.style.display = "none"
        document.getElementById("appt-btn").innerHTML = "Show Details"

    }

}

function billsBtn() {
    let  bills_heading = document.getElementById("bills-heading")
    let bills_table = document.getElementById("bills-table")

    if (bills_heading.style.display === "none" && bills_table.style.display === "none") {
        bills_heading.style.display = "block";
        bills_table.style.display = "block";
        document.getElementById("bills-btn").innerHTML = "Hide Details"
    
    } else {
        bills_heading.style.display = "none";
        bills_table.style.display = "none"
        document.getElementById("bills-btn").innerHTML = "Show Details"

    }
}