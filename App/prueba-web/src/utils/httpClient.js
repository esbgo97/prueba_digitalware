import Axios from 'axios'

const http = Axios.create({
    baseURL: "https://localhost:5001/api/",
    headers:{
        "Accept":"*",
        "Content-Type":"application/json"
    }
})

export default http 