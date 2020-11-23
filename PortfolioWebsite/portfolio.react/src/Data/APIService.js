import axios from 'axios'
import Project from '../Models/Project'


export async function getProjects(){
        return await axios.get("https://portfolio-api-marcelo.herokuapp.com/api/project/")
            .then(response => {
                const projectsFound =  response.data;
                console.log(projectsFound);
                
                return projectsFound;
            })
    }

export async function getProjectBySlug(slugParam){
    const projects = await getProjects();
    
    return projects.find(p  => p.slug === slugParam);
}

export async function addNewProject(){
    
}


