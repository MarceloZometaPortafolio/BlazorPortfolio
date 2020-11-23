import React from "react"
import { Link } from 'react-router-dom'

const ProjectLink = (props) => {
    return(
        <div>
            <Link to={"/projects/" + props.project.slug}>
                <p>{props.project.title}</p>
                </Link>
        </div>
    );
}

export default ProjectLink;