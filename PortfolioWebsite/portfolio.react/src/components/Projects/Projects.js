import React, { useEffect, useState } from 'react';
import { Card, CardContent, CardHeader } from '@material-ui/core';
import APIService from '../../Data/APIService';
import { makeStyles } from '@material-ui/core/styles';
import ProjectLink from './ProjectLink'

const useStyles = makeStyles((theme) => ({
    body: {
      textAlign : "left"
    },
  }));


const Projects = () => {
    const classes = useStyles();      
    const [projects, setProjects] = useState([]);

    const fetchData = async () => {
        const projectsReturned = await APIService.getProjects();
            
        setProjects(projectsReturned);
    } 

    useEffect(() => {
         fetchData();
    }, []);

    return (
        <div id="Projects">
            <Card className={classes.body}>
                <CardHeader title="Projects"/>
                <CardContent>
                    {projects.map((p) => 
                        <div key={p.id}>
                            <ProjectLink project={p} {...p}/>
                        </div>
                    )}
                </CardContent>
            </Card>        
        </div>
    );
}

export default Projects;