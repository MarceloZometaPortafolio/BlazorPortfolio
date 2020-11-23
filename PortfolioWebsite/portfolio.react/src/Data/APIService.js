import axios from 'axios'
import Project from '../Models/Project'

const APIService = {
    getProjects: async function(){
        return await axios.get("https://portfolio-api-marcelo.herokuapp.com/api/project/")
            .then(response => {
                const projectsFound =  response.data;
                console.log(projectsFound);
                
                return projectsFound;
            })
        },

    getProjectBySlug: async function(slugParam){
        const projects = await APIService.getProjects();
        
        const projectFound = projects.find(p  => p.slug === slugParam);
        console.log("Project found " + projectFound);
        
        return projectFound;
    },

    getLanguagesByProjectId: async function (idParam){
        return await axios.get("https://portfolio-api-marcelo.herokuapp.com/api/project/getlanguages/" + idParam)
            .then(response => {
                const languagesFound = response.data;
                console.log("Languages found " + languagesFound);

                return languagesFound;
            })
    },

    getTechnologiesByProjectId: async function (idParam){
        return await axios.get("https://portfolio-api-marcelo.herokuapp.com/api/project/gettechnologies/" + idParam)
            .then(response => {
                const technologiesFound = response.data;
                console.log("Technologies found " + technologiesFound);

                return technologiesFound;
            })
    },

    getPlatformsByProjectId: async function (idParam){
        return await axios.get("https://portfolio-api-marcelo.herokuapp.com/api/project/getplatforms/" + idParam)
            .then(response => {
                const platformsFound = response.data;
                console.log("Platforms found " + platformsFound);

                return platformsFound;
        })
    }
}

export default APIService;

