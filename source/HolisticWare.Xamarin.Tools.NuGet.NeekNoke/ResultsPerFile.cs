using System.Collections.Generic;

namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke;

public class ResultsPerFile
{
    public
        string
                                        File
    {
        get;
        set;
    }

    public 
        Dictionary
                <
                    string,                             // nuget_id
                    (
                        string version_current,         // version_current
                        string[] versions_updateable    // versions_updateable
                    )
                >
                package_versions = null;

    public
        Dictionary
                <
                    string,                             // nuget_id
                    (
                        string version_current,         // version_current
                        string[] versions_updateable    // versions_updateable
                    )
                > 
                                        PackageVersions
    {
        get
        {
            return package_versions;
        }
        
        protected set
        {
            package_versions = value;
            
            return;
        }
    }
    
    protected 
        Dictionary
            <
                string,                             // file
                (
                    string nuget_id,                // nuget_id
                    string version_current,         // version current (from file)
                    string[] versions_upgradeable,  // version upgradeable (from nuget feed[s])
                    string text_snippet_original,   // text snippet original (form file to preserve formatting) 
                    string text_snippet_new         // text snippet new (from nuget feed changed version)
                )
            > 
                package_references = null;

    public
        Dictionary
            <
                string,                             // file
                (
                    string nuget_id,                // nuget_id
                    string version_current,         // version current (from file)
                    string[] versions_upgradeable,  // version upgradeable (from nuget feed[s])
                    string text_snippet_original,   // text snippet original (form file to preserve formatting) 
                    string text_snippet_new         // text snippet new (from nuget feed changed version)
                )
            > 
                                        PackageReferences
    {
        get
        {
            return package_references;
        }
        
        protected set
        {
            package_references = value;
            
            return;
        }
    }

    public
        List
            <
                (
                    string nuget_id,                // nuget_id
                    string version_current          // version current (from file)
                )
            > 
                                        PackagesFailed
    {
        get
        {
            return packages_failed;
        }
        
        protected set
        {
            packages_failed = value;
            
            return;
        }
    }

    protected 
        List
            <
                (
                    string nuget_id,                // nuget_id
                    string version_current         // version current (from file)
                )
            > 
                                        packages_failed = null;

    public 
        Dictionary
                <
                    string,                             // file with references (changed if noked)
                    (
                        string file_backup,             // file backup with original content
                        string content,                 // contnent (changed if noked)
                        string content_backup           // content backup with original content
                    )
                > 
        Log
    {
        get
        {
            return log;
        }

        protected set
        {
            log = value;
            
            return;
        }
    }

    protected
        Dictionary
                <
                    string,                             // file with references (changed if noked)
                    (
                        string file_backup,             // file backup with original content
                        string content,                 // contnent (changed if noked)
                        string content_backup           // content backup with original content
                    )
                >
                log = null;

    public
                                        ResultsPerFile
                                            (
                                            )
    {
        log = new Dictionary
                        <
                            string,                             // file with references (changed if noked)
                            (
                                string file_backup,             // file backup with original content
                                string content,                 // contnent (changed if noked)
                                string content_backup           // content backup with original content
                            )
                        >
                        ();
        
        package_versions = new Dictionary
                                        <
                                            string,
                                            (
                                                string version_current,
                                                string[] versions_updateable
                                            )
                                        >
                                        ();
        
        package_references = new Dictionary
                                        <
                                            string,                             // file
                                            (
                                                string nuget_id,                // nuget_id
                                                string version_current,
                                                string[] versions_upgradeable,
                                                string text_snippet_original,
                                                string text_snippet_new
                                            )
                                        >
                                            ();

        packages_failed = new List
                                <
                                    (
                                        string nuget_id,
                                        string version_current
                                    )
                                >
                                    ();

        return;
    }

}