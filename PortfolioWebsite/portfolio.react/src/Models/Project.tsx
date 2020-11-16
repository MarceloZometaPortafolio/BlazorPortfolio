import axios from 'axios';

interface Project {
    id: number,
    title: string,
    requirement: string,
    design: string,
    completionDate: string
}

export async function getProjects(){
    return await axios.get("https://portfolio-api-marcelo.herokuapp.com/api/project/")
        .then(response => {
            const projectsFound =  response.data;
            return projectsFound;
        })
    }

export default Project