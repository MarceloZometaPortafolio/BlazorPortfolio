import React, { useEffect, useState } from 'react'
import { Card, CardContent, CardHeader, Container } from '@material-ui/core';
import ReactMarkdown from 'react-markdown'
import APIService from '../../Data/APIService'
import { makeStyles } from '@material-ui/core/styles';
import CategoryCard from './CategoryCard';

const useStyles = makeStyles((theme) => ({
    leftAligned: {
      textAlign : "left"
    },
  }));

const DetailProject = (props) => {
    const slug = props.match.params.slug;        
    const [project, setProject] = useState([]);
    const [languages, setLanguages] = useState([]);
    const [platforms, setPlatforms] = useState([]);
    const [technologies, setTechnologies] = useState([]);

    const classes = useStyles();

    const getProject = async () => {
        const projectFound = await APIService.getProjectBySlug(slug);
        //APIService.getProjectBySlug(slug)
        return projectFound;
    }

    const getLanguages = async() => {
        const languagesFound = await APIService.getLanguagesByProjectId(project.id);

        return languagesFound;
    }

    const getTechnologies = async() => {
        const technologiesFound = await APIService.getTechnologiesByProjectId(project.id);
        
        return technologiesFound;
    }

    const getPlatforms = async() => {
        const platformsFound = await APIService.getPlatformsByProjectId(project.id);
        
        return platformsFound;
    }

    const getData = async() => {        
        setLanguages(await getLanguages());
        setTechnologies(await getTechnologies());
        setPlatforms(await getPlatforms());        
    }

    useEffect(() => {       
        getProject()
        .then(project => {
            setProject(project);
            getData();
        })                    
    }, [project.id]);

    return(
        <div>
            <Card>
                <CardHeader title={project.title}/>
                <CardContent>
                    <CardHeader title="Requirements" className={classes.leftAligned}/>
                    <ReactMarkdown children={project.requirement} className={classes.leftAligned}/>

                    <CardHeader title="Design" className={classes.leftAligned}/>
                    <ReactMarkdown children={project.design} className={classes.leftAligned}/>

                    <CardHeader title="Completion Date" className={classes.leftAligned}/>
                    <label className={classes.leftAligned}>{project.completionDate}</label>   

                    <CardHeader title="Languages" className={classes.leftAligned}/>
                    <CategoryCard category={languages}/>
                   

                    <CardHeader title="Technologies" className={classes.leftAligned}/>
                    <CategoryCard category={technologies}/>

                    <CardHeader title="Platforms" className={classes.leftAligned}/>
                    <CategoryCard category={platforms}/>
                </CardContent>
            </Card>
        </div>
    );
}

export default DetailProject