import React from 'react'
import axios from 'axios'

export async function getProjects(){
        return axios.get("https://portfolio-api-marcelo.herokuapp.com/api/project/")
            .then(response => {
                const projectsFound =  response.data;
                console.log(projectsFound);
                
                return projectsFound;
            })
    }


