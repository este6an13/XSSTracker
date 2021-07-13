
const conn = new signalR.HubConnectionBuilder().withUrl('/recordsHub').build()

conn.on('ReceiveMessage', (URL, XSSClass) => {

    const date = new Date().toLocaleTimeString()

    const tr = document.createElement('tr')

    const td_date = document.createElement('td')
    td_date.innerHTML = date
    const td_url = document.createElement('td')
    td_url.innerHTML = URL
    const td_xss_class = document.createElement('td')
    td_xss_class.innerHTML = (XSSClass == 1) ? 'Warning' : 'Safe'

    tr.appendChild(td_date)
    tr.appendChild(td_xss_class)
    tr.appendChild(td_url)

    td_xss_class.style = (XSSClass == 1) ? 'color:#df4759' : 'color:#42ba96'

    $("#records_table tbody").prepend(tr);

    if (XSSClass == 1) {

        Push.create('XSS Tracker', {
            body: 'A potential XSS was detected'
        });
    }
});

conn.start().catch(err => console.error(err.toString()))
