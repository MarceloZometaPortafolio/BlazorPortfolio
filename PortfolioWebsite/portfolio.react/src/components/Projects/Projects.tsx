import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Button, Card, CardContent, CardHeader, Paper } from '@material-ui/core';
import { Add, AddCircle, InsertChart } from '@material-ui/icons';

interface Project {
    id: number,
    title: string,
    requirement: string,
    design: string,
    completionDate: string
}

const Projects = () => {
    const [projects, setProjects] = useState([]);

    let mainFeaturedPost = {
        title: "",
        description:
          "Multiple lines of text that form the lede, informing new readers quickly and efficiently about what's most interesting in this post's contents.",
        image: 'https://source.unsplash.com/random',
        imageText: 'main image description',
        linkText: 'Continue reading…',
      };

    function getProjects(){
        return axios.get("https://portfolio-api-marcelo.herokuapp.com/api/project/")
            .then(response => {
                const projectsFound =  response.data;
                console.log(projectsFound);
                setProjects(projectsFound);
            })
    } 

    useEffect(() => {
        getProjects();
    }, []);

    return (
        <div id="Projects">  
            {/* <form>
                <input
                    type="text"
                    placeholder="Search..."
                    onChange={handleSearchInputChange}
                    value={search}  
                />
            </form>       */}
            <Card>                
                <CardContent>
                    <CardHeader title="Projects"/>                        
                    {projects.map((item : Project) => 
                        <div key={item.id}>{item.title}</div>)}            
                </CardContent>                
            </Card>
            <Button variant="contained" color="primary" startIcon={<AddCircle/>}>
                Add New Project
            </Button>
        </div>
    );
}

export default Projects;