import axios from 'axios'
import Project from '../Models/Project'


interface NewProjectProps{
    project : Project
}

export async function getProjects(){
        return axios.get("https://portfolio-api-marcelo.herokuapp.com/api/project/")
            .then(response => {
                const projectsFound =  response.data;
                console.log(projectsFound);
                
                return projectsFound;
            })
    }

export async function addNewProject(props: NewProjectProps){
    
}


